using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Speed & direction
    private float speed;
    [SerializeField] private float baseSpeed = 3f;
    [SerializeField] private float maxSpeed = 6f;
    [SerializeField] private float acceleration = 10f;
    [SerializeField] private float deceleration = 10f;
    private Vector2 direction;
    private bool accelerating = false;
    private bool slowingDown = false;
    private bool nowCardinal = false;
    private bool wasDiagonal = false;
    private bool returningStick = false;
    private float lastMagnitude = 0f;

    // Time
    [SerializeField] private float timeBeforeDirectionChange = 0.08f;
    private float changeTimer;
    private bool isChanging = false;
    private Vector2 changingDirection;

    // References

    public GameObject PauseMenu;
    private Rigidbody2D _rb;
    private Scimitar scimitar;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        scimitar = transform.GetChild(0).GetComponent<Scimitar>();
        speed = baseSpeed;
    }

    private void Update()
    {
        if (isChanging)
        {
            changeTimer -= Time.deltaTime;

            if (changeTimer <= 0)
            {
                ChangeDirection(changingDirection);
                isChanging = false;
            }
        }

        if (accelerating)
        {
            if (speed < maxSpeed)
            {
                speed += acceleration * Time.deltaTime;
            }
        }
        else if (slowingDown)
        {
            if (speed > 0)
            {
                speed -= deceleration * Time.deltaTime;
            }
            else
            {
                direction = Vector2.zero;
                speed = baseSpeed;
                slowingDown = false;
                // GetComponent<Animator>().SetBool("walking", false);
            }
        }
    }

    public void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + direction.normalized * speed * Time.fixedDeltaTime);
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();

        if (context.started)
        {
            speed = baseSpeed;
            // GetComponent<Animator>().SetBool("walking", true);
        }

        if (!context.canceled && input != Vector2.zero)
        {
            slowingDown = false;
            accelerating = true;
            wasDiagonal = direction.x != 0 && direction.y != 0;
            nowCardinal = (input.x == 0) != (input.y == 0);
            returningStick = input.magnitude < lastMagnitude - 0.01f;
            lastMagnitude = input.magnitude;

            if ((wasDiagonal && nowCardinal) || returningStick)
            {
                changingDirection = input;
                changeTimer = timeBeforeDirectionChange;
                isChanging = true;
            }
            else
            {
                isChanging = false;
                ChangeDirection(input);
            }
        }
        else
        {
            lastMagnitude = 0f;
            isChanging = false;
            slowingDown = true;
            accelerating = false;
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started && !scimitar.attacking)
        {
            scimitar.Attack();
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            PauseMenu.SetActive(!PauseMenu.activeSelf);
            Time.timeScale = Convert.ToInt16(Time.timeScale == 0);
        }
    }

    private void ChangeDirection(Vector2 newDirection)
    {
        direction = newDirection;
        float alpha = Mathf.Atan2(newDirection.y, newDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, alpha);
    }
}
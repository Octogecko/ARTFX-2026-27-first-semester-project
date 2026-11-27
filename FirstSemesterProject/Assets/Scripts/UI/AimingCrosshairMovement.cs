using UnityEngine;
using UnityEngine.InputSystem;

public class AimingCrosshairMovement : MonoBehaviour
{
    [SerializeField] private float startingDistance = 3f;
    [SerializeField] private float speed = 5f;

    private GameObject player;
    private float grapplingHookRange;
    private Vector2 mousePosition;
    private Vector3 movement = Vector3.zero;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        grapplingHookRange = player.GetComponent<PlayerMovement>().GetGrapplingHookRange();
        mousePosition = GetMousePosition();
    }

    private void OnEnable()
    {
        transform.position = player.transform.position + player.transform.right * startingDistance;
        FollowCrosshair();
    }

    void Update()
    {
        if (GetMousePosition() != mousePosition && movement == Vector3.zero)
        {
            FollowMouse();
        }
        else if (mousePosition == GetMousePosition() && transform.position != (Vector3)GetMousePosition())
        {
            FollowCrosshair();
        }

        if ((player.transform.position - transform.position).sqrMagnitude > grapplingHookRange * grapplingHookRange)
        {
            transform.localPosition = transform.localPosition.normalized * grapplingHookRange;
            FollowCrosshair();
        }

        mousePosition = GetMousePosition();
    }

    private void FixedUpdate()
    {
        transform.position += movement * speed * Time.fixedDeltaTime;
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        if (!context.canceled && CameraMovement.state == CameraMovement.CameraState.AIMING)
        {
            movement = context.ReadValue<Vector2>().normalized;
        }
        else if (context.canceled)
        {
            FollowCrosshair();
            movement = Vector3.zero;
        }
    }
    private Vector2 GetMousePosition()
    {
        return Mouse.current.position.ReadValue();
    }

    private void FollowMouse()
    {
        transform.position = (Vector2) Camera.main.ScreenToWorldPoint(GetMousePosition());

    }

    private void FollowCrosshair()
    {
        Mouse.current.WarpCursorPosition(Camera.main.WorldToScreenPoint(transform.position));
        mousePosition = GetMousePosition();
    }
}

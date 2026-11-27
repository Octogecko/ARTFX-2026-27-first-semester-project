using UnityEngine;
using UnityEngine.InputSystem;

public class AimingCrosshairMovement : MonoBehaviour
{
    [SerializeField] private float startingDistance = 3f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float aimRange = 1f;

    private GameObject[] lockableObjects;
    public GameObject lockedObject = null;
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

    private void OnDisable()
    {
        lockedObject = null;
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

        lockableObjects = GameObject.FindGameObjectsWithTag("Enemy");
        if (lockableObjects.Length > 0)
        {
            GameObject closestObject = null;
            foreach (GameObject obj in lockableObjects)
            {
                if (closestObject == null && Vector3.Distance(transform.position, obj.transform.position) < aimRange)
                {
                    closestObject = obj;
                }
                else if (closestObject != null && Vector3.Distance(transform.position, obj.transform.position) < Vector3.Distance(transform.position, closestObject.transform.position))
                {
                    closestObject = obj;
                }
            }
            lockedObject = closestObject;
        }

        mousePosition = GetMousePosition();

        float opposite = transform.position.y - player.transform.position.y;
        float adjacent = transform.position.x - player.transform.position.x;
        float alpha = Mathf.Atan2(opposite, adjacent) * Mathf.Rad2Deg;
        player.transform.rotation = Quaternion.Euler(0, 0, alpha);
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

using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private GameObject crosshair;

    public static CameraState state = CameraState.NORMAL;

    [SerializeField] private float distanceWhileMoving = 3f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        switch (state)
        {
            case CameraState.NORMAL:
                transform.position = player.transform.position;
                break;
            case CameraState.MOVING:
                transform.position = player.transform.position + player.transform.right * distanceWhileMoving;
                break;
            case CameraState.AIMING:
                transform.position = (player.transform.position + crosshair.transform.position) / 2;
                break;
        }
    }

    public enum CameraState
    {
        NORMAL,
        MOVING,
        AIMING
    }
}

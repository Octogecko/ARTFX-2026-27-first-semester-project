using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SC_Palace_CameraLocker : MonoBehaviour
{

    public float Up,Down,Right,Left;
    private Vector3 BasePos;

    private void Start()
    {
        BasePos = transform.position;
    }
    public IEnumerator MoveCamera()
    {
        if (Up != 0 || Down != 0 || Right != 0 || Left != 0)
        {
            while (SC_Palace_CameraManager.Instance.Cam.Target.TrackingTarget = transform)
            {
                if (FindAnyObjectByType<PlayerMovement>().transform.position.y <= Up + BasePos.y)
                {
                    Debug.Log("a");
                    transform.position = new Vector3(transform.position.x, FindAnyObjectByType<PlayerMovement>().transform.position.y, transform.position.z);
                }
                yield return new WaitForEndOfFrame();
            }
            transform.position = BasePos;
        }
    }
}

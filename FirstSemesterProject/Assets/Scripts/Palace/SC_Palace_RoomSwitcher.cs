using Unity.Cinemachine;
using UnityEngine;

public class SC_Palace_RoomSwitcher : MonoBehaviour
{

    public GameObject LockTarget1;
    public GameObject LockTarget2;

    private void OnTriggerExit2D(Collider2D collision)
    {
        Transform TrackingTarget = SC_Palace_CameraManager.Instance.Cam.Target.TrackingTarget;
        if (TrackingTarget  == LockTarget1.transform) 
        {
            StopCoroutine(LockTarget1.GetComponent<SC_Palace_CameraLocker>().MoveCamera());
            SC_Palace_CameraManager.Instance.Cam.Target.TrackingTarget = LockTarget2.transform;
            StartCoroutine(LockTarget2.GetComponent<SC_Palace_CameraLocker>().MoveCamera());
        }
        else
        {
            StopCoroutine(LockTarget2.GetComponent<SC_Palace_CameraLocker>().MoveCamera());
            SC_Palace_CameraManager.Instance.Cam.Target.TrackingTarget = LockTarget1.transform;
            StartCoroutine(LockTarget1.GetComponent<SC_Palace_CameraLocker>().MoveCamera());
        }
    }
}

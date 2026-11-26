using Unity.Cinemachine;
using UnityEngine;

public class SC_Palace_CameraManager : MonoBehaviour
{

    public CinemachineCamera Cam;

    public static SC_Palace_CameraManager Instance;
    void Awake()
    {
        Cam = FindAnyObjectByType<CinemachineCamera>();
        Instance = this;
    }




}

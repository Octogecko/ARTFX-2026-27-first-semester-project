using UnityEngine;

public class LoadGame : MonoBehaviour
{
    public void Loading()
    {
        SaveController.Instance.LoadGame();
    }
}

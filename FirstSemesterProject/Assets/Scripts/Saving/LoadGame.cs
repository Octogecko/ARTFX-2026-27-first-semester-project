using UnityEngine;

public class LoadGame : MonoBehaviour
{
    public void Loading()
    {
        Time.timeScale = 1;
        SaveController.Instance.LoadGame();
    }
}

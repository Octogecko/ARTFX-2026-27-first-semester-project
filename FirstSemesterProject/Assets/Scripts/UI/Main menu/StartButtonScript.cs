using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButtonScript : MonoBehaviour
{
    public Button start;

    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
    public void ChangeScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(3);
    }
}

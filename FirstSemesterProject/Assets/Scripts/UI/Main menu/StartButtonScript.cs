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
        SceneManager.LoadScene(2);
    }
}

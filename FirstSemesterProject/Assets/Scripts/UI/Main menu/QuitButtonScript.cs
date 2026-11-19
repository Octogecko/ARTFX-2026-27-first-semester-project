using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuitButtonScript : MonoBehaviour
{
    public Button quit;

    private void Start()
    {

    }
    private void Update()
    {

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
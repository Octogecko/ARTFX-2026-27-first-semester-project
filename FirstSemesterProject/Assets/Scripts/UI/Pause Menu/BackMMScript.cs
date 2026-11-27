using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackMMScript : MonoBehaviour
{
    public Button mainMenu;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("Main Menu");
    }
}

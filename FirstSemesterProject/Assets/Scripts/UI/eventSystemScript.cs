using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class eventSystemScript : MonoBehaviour
{
    public Canvas gameOver;
    public Button boutton;
    public EventSystem eventSystem;
    void Start()
    {
       
    }
    void Update()
    {

    }
        
    public void OpenGameOver()
    {
        gameObject.SetActive(true);
        eventSystem.SetSelectedGameObject(boutton.gameObject);
        
    }
}

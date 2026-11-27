using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class eventSystemScript : MonoBehaviour
{
    public Canvas Canva;
    public Button boutton;
    public EventSystem eventSystem;

    void Start()
    {
       
    }
    void Update()
    {

    }
        
    public void OpenCanva()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        eventSystem.SetSelectedGameObject(boutton.gameObject);        
    }
}

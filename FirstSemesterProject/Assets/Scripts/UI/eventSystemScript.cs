using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class eventSystemScript : MonoBehaviour
{
    public Canvas gameOver;
    public Button boutton;
    void Start()
    {
       
    }
    void Update()
    {
        if (gameOver.enabled == true)
        {
            gameObject.GetComponent<EventSystem>().firstSelectedGameObject = boutton.gameObject;
        }

    }
        
}

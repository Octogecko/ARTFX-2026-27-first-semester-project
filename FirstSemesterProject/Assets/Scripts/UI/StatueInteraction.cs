using UnityEngine;
using UnityEngine.InputSystem;

public class StatueInteraction : MonoBehaviour
{
    public Canvas canvas;
    private bool inZone;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Interaction(InputAction.CallbackContext context)
    {
        if (context.started && inZone)
        {
            Time.timeScale = 0;
            canvas.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("t'es dans la zone");
            inZone = true;
            InteractionUI.Instance.VisibleInteraction("Press");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("t'es plus dans la zone");
            inZone = false;
            InteractionUI.Instance.HideInteraction();
        }
    }
}

using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InteractionUI : MonoBehaviour
{
    public static InteractionUI Instance;
    public TextMeshProUGUI interactibleText;
    public Image image;

    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VisibleInteraction(string text)
    {
        Debug.Log(text);
        image.gameObject.SetActive(true);
        interactibleText.gameObject.SetActive(true);
        interactibleText.text = text;
    }

    public void HideInteraction()
    {
        Debug.Log("a plu le txt");        
        interactibleText.gameObject.SetActive(false);
        image.gameObject.SetActive(false);
    }
}

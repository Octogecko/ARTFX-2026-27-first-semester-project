using UnityEngine;
using TMPro;

public class InteractionUI : MonoBehaviour
{
    public static InteractionUI Instance;
    public TextMeshProUGUI interactibleText;

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
        interactibleText.gameObject.SetActive(true);
        interactibleText.text = text;
    }

    public void HideInteraction()
    {
        Debug.Log("a plu le txt");
        interactibleText.gameObject.SetActive(true);
    }
}

using UnityEngine;
using UnityEngine.UI;

public class SaveStatueBouttonScript : MonoBehaviour
{
    public Button button;
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void SavingChangesStatue()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsScrip : MonoBehaviour
{
    public Button credit;

    private void Start()
    {

    }
    private void Update()
    {

    }
    public void ChangeScene()
    {
        SceneManager.LoadScene("CreditsScene");
    }
}

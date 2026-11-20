using System;
using UnityEngine;
using UnityEngine.UI;

public class ResumeGameScript : MonoBehaviour
{
    public Button resume;
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void GameResumed()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}

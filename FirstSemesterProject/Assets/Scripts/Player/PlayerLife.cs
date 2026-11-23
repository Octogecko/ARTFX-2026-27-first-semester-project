using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    /*[SerializeField] private int startingHP = 3;
    [SerializeField] private int maxHP = 3;*/

    public Canvas GameOver;
    public GameObject hearts;
    List<GameObject> listhearts = new List<GameObject>();

    private int hp;

    void Start()
    {
        for (int i = 0; i < hearts.transform.childCount; i++)
        {
            listhearts.Add(hearts.transform.GetChild(i).GetChild(0).gameObject);
        }
        hp = listhearts.Count;
        Debug.Log(listhearts.Count);
    }
    
    public void Heal()
    {
        listhearts[hp].GetComponent<Image>().enabled = true;
        hp += 1;
    }

    public void Hurt()
    {
        hp -= 1;
        if (hp <= 0)
        {
            Death();
        }
        else
        {
            listhearts[hp].GetComponent<Image>().enabled = false;
        }
    }

    public void Death()
    {
        GameOver.GetComponent<Canvas>().enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Hurt();
            Debug.Log(hp);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Hurt();
            Debug.Log(hp);
        }
    }

    public int GetHp()
    {
        return hp;
    }

    public void SetHp(int savedHp)
    {
        hp = savedHp;
    }
}

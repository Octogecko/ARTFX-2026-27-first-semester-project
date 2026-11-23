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


    List<List> listHearts = new List<List>();
    List<Image> heart = new List<Image>();


    private int heartImage;
    private int hp;

    void Start()
    {
        for (int i = 0; i < hearts.transform.childCount; i++)
        {
            heart.Add(hearts.transform.GetChild(i).GetComponent<Image>());
            listHearts.Add(heart);
        }
        hp = listHearts.Count;
        Debug.Log(listHearts.Count);
    }
    
    public void Heal()
    {
        listHearts[hp[2]].GetComponent<Image>().enabled = true;
        hp += 1;
    }

    public void Hurt()
    {
        
        if (hp - 1 <= 0)
        {
            Death();
        }
        else
        {
            listHeartImage[hp+3].GetComponent<Image>().enabled = false;
        }
        hp -= 1;
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

    public int GetHp()
    {
        return hp;
    }

    public void SetHp(int savedHp)
    {
        hp = savedHp;
    }
}

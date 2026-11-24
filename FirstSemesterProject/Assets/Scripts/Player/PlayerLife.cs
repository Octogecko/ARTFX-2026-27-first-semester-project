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

    List<Image> heart = new List<Image>();
    List<List<Image>> listHearts;
   
    private int heartImage;
    private int hp;

    void Start()
    {
        for (int i = 0; i < hearts.transform.childCount; i++)
        {
            heart.Add(hearts.transform.GetChild(i).GetComponentInChildren<Image>());
            listHearts.Add(heart);
        }
        hp = listHearts.Count;
        heartImage = heart.Count * listHearts.Count;
        Debug.Log(listHearts.Count);
        Debug.Log(heart.Count);
        Debug.Log(heartImage);
    }
    
    public void Heal()
    {
        listHearts[hp][heartImage].GetComponent<Image>().enabled = true;
        hp += 1;
    }

    public void Hurt()
    {
        foreach (List<Image> l in listHearts)
        {
            foreach (Image image in l)
            {
                for (int i = 2; i >= 0; i--)
                {
                    if (i == 0)
                    {
                        hp -= 1;
                    }
                    else
                    {
                        image.GetComponent<Image>().enabled = false;
                    }
                }
            }

            if (hp <= 0)
            {
                GameOver.GetComponent<Canvas>().enabled = true;
            }

            /*if (hp - 1 <= 0)
            {
                Death();
            }
            else
            {
                //listHearts[hp+3].GetComponent<Image>().enabled = false;
            }
            hp -= 1;*/
        }
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

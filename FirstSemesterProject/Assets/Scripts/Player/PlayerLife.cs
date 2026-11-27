using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int startingHP;
    [SerializeField] private int maxHP = 3;

    public Canvas GameOver;
    public GameObject hearts;

    //List<Image> heart = new List<Image>();
    //List<List<Image>> listHearts = new List<List<Image>>();
   
    private int heartImage;
    int hp;
    

    void Start()
    {
        /*Debug.Log("childCount: " + hearts.transform.childCount);
        for (int i = 0; i < hearts.transform.childCount; i++)
        {
            // add heart in heart liste
            var child = hearts.transform.GetChild(i);
            Debug.Log(child);
            for (int j = 0;  j < child.childCount; j++)
            {
                Image image = child.GetChild(j).GetComponent<Image>();
                listHearts[i].Add(image);
                heart.Add(image);
            }
            listHearts.Add(heart);
        }
        hp = listHearts.Count;

        heartImage = heart.Count * listHearts.Count;
        Debug.Log("Il y a " + listHearts.Count + " listes dans listHeart.");
        Debug.Log("Il y a " + heart.Count + " d'elements images dans une liste heart");
        Debug.Log("il y a en tout " + heartImage + " images.");*/


                //Ce qu'il faut faire pour la prochaine fois pour le player life (je n'en peux plus) 
           // Dans ce start faire avec le load -> recupérer l'état des coeur en fonction des hp et du coup ou on en est avec "heartImage". -> a voir plus tard pour savoir comment l'implémenter... Sinon je vais crashout...
        hp = maxHP;
        heartImage = 2;
    }
    
    public void Heal()
    {
        Debug.Log("gaigned life !");
        if (hp < maxHP)
        {
            heartImage += 1;
            if (heartImage > 2)
            {
                hp += 1;
                heartImage = 1;                
            }
            hearts.transform.GetChild(hp - 1).transform.GetChild(heartImage).GetComponent<Image>().enabled = true;
        }
        
           
    }

    public void Hurt()
    {
        hearts.transform.GetChild(hp - 1).transform.GetChild(heartImage).GetComponent<Image>().enabled = false;
        heartImage -= 1;
        if (heartImage == 0)
        {
            hp -= 1;
            heartImage = 2;
        }
        if (hp == 0)
        {
            Death();
        }
    }

    public void Death()
    {
        hp = maxHP;
        GameOver.GetComponent<eventSystemScript>().OpenCanva();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Hurt();
            Debug.Log(hp);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Life"))
        {
            Heal();
            collision.gameObject.SetActive(false);
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

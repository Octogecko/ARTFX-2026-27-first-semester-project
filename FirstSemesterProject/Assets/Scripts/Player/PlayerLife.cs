using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int startingHP = 3;
    [SerializeField] private int maxHP = 3;
    private int hp;

    void Start()
    {
        hp = startingHP;
    }
    
    public void Heal()
    {
        hp++;
    }

    public void Hurt()
    {
        hp--;
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

using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLife : MonoBehaviour
{
    [Header("Overall Life")]

    [SerializeField] private int startingHP = 3;
    [SerializeField] private int maxHP = 3;
    private int hp;

    [Header("Potions")]

    [SerializeField] private int potionLevel = 0;
    [SerializeField] private List<int> potionPowerPerLevel = new List<int> { 1, 2, 3, 4 };

    void Start()
    {
        hp = startingHP;
    }

    public void OnDrinkPotion(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Heal(potionPowerPerLevel[potionLevel]);
        }
    }

    public void Heal(int amount)
    {
        hp += amount;
    }

    public void Hurt(int amount)
    {
        hp -= amount;
    }

    public int GetHp()
    {
        return hp;
    }

    public void SetHp(int savedHp)
    {
        hp = savedHp;
    }

    public void LevelUpPotions()
    {
        potionLevel++;
    }
}

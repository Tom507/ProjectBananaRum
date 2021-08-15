using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public int Gold = 8;
    public int Swords = 5;
    public int Axes = 4;
    public int Lances = 6;

    public int priceSword = 5;
    public int priceAxe = 7;
    public int priceLance = 3;

    void Start()
    {
        if (!Instance) { Instance = this; } else
        {
            DestroyImmediate(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    public bool Buy(Soldier.Weapon weapon)
    {
        int price = 0;
        switch (weapon)
        {
            case Soldier.Weapon.Sword:
                price = priceSword;
                break;
            case Soldier.Weapon.Axe:
                price = priceAxe;
                break;
            case Soldier.Weapon.Lance:
                price = priceLance;
                break;
        }
        return Buy(price);
    }
    public bool Buy(int gold)
    {
        if(Gold >= gold)
        {
            Gold -= gold;
            return true;
        }
        else { return false; }
    }
}
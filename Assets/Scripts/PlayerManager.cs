using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int strengthOfBattleShip = 10;
    public int battleShipReward = 0;

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
        if (!Instance) 
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else
        {
            DestroyImmediate(gameObject);
        }
        
    }

    public int countSoldiers()
    {
        return Swords + Axes + Lances;
    }

    public bool soldierExists(Soldier.Weapon weapon)
    {
        switch (weapon)
        {
            case Soldier.Weapon.Sword:
                return Swords > 0;
            case Soldier.Weapon.Axe:
                return Axes > 0;
            case Soldier.Weapon.Lance:
                return Lances > 0;
        }
        return false;
    }
    public void removeSoldier(Soldier.Weapon weapon)
    {
        Debug.Log("Remove Soldier:: " + weapon);
        switch (weapon)
        {
            case Soldier.Weapon.Sword:
                Swords--;
                break;
            case Soldier.Weapon.Axe:
                Axes--;
                break;
            case Soldier.Weapon.Lance:
                Lances--;
                break;
        }
    }
    public bool Buy(Soldier.Weapon weapon)
    {
        int price = 0;
        switch (weapon)
        {
            case Soldier.Weapon.Sword:
                price = priceSword;
                if (Buy(price))
                {
                    Swords++;
                    return true;
                }
                
                break;
            case Soldier.Weapon.Axe:
                price = priceAxe;
                if (Buy(price))
                {
                    Axes++;
                    return true;
                }
                break;
            case Soldier.Weapon.Lance:
                price = priceLance;
                if (Buy(price))
                {
                    Lances++;
                    return true;
                }
                break;
        }
        return false;
    }
    public void addSoldier(Soldier.Weapon weapon)
    {
        switch (weapon)
        {
            case Soldier.Weapon.Sword:
                Swords++;
                break;
            case Soldier.Weapon.Axe:
                Axes++;
                break;
            case Soldier.Weapon.Lance:
                Lances++;
                break;
        }
    }
    public bool Buy(int gold)
    {
        if(Gold >= gold)
        {
            Gold = Gold - gold;
            return true;
        }
        else { return false; }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldUI : MonoBehaviour
{

    public Text swordsAmount;
    public Text axeAmount;
    public Text lanceAmount;

    public Text goldAmount;

    PlayerManager pm;

    private void Start()
    {
        pm = PlayerManager.Instance;
        swordsAmount.text = pm.Lances.ToString();
        axeAmount.text = pm.Axes.ToString();
        lanceAmount.text = pm.Lances.ToString();

        goldAmount.text = pm.Gold.ToString();
    }
    public void BuySword()
    {
        pm.Buy(Soldier.Weapon.Sword);
        swordsAmount.text = pm.Lances.ToString();
    }
    public void BuyAxe()
    {
        pm.Buy(Soldier.Weapon.Axe);
        axeAmount.text = pm.Axes.ToString();
    }
    public void BuyLance()
    {
        pm.Buy(Soldier.Weapon.Lance);
        lanceAmount.text = pm.Lances.ToString();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Input1"))
        {
            BuySword();
        }
        if (Input.GetButtonDown("Input2"))
        {
            BuyAxe();
        }
        if (Input.GetButtonDown("Input3"))
        {
            BuyLance();
        }
    }
}

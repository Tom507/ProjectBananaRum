using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectUi : MonoBehaviour
{
    public GameObject swordSelcted;
    public GameObject axeSelected;
    public GameObject lanceSelected;

    public CatapultController catControll;

    public Text swordsAmount;
    public Text axeAmount;
    public Text lanceAmount;

    PlayerManager pm;

    public void UpdateUI()
    {
        Debug.Log("UpdateUI");
        swordsAmount.text = "#" + pm.Swords.ToString();
        axeAmount.text = "#" + pm.Axes.ToString();
        lanceAmount.text = "#" + pm.Lances.ToString();
    }
    private void Start()
    {
        pm = PlayerManager.Instance;

        swordsAmount.text = "#" + pm.Lances.ToString();
        axeAmount.text = "#" + pm.Axes.ToString();
        lanceAmount.text = "#" + pm.Lances.ToString();
    }

    public void SelectSword()
    {
        swordSelcted.SetActive(true);
        axeSelected.SetActive(false);
        lanceSelected.SetActive(false);
        catControll.currentSoldier = Soldier.Weapon.Sword;
    }
    public void SelectAxe()
    {
        swordSelcted.SetActive(false);
        axeSelected.SetActive(true);
        lanceSelected.SetActive(false);

        catControll.currentSoldier = Soldier.Weapon.Axe;
    }
    public void SelectLance()
    {
        swordSelcted.SetActive(false);
        axeSelected.SetActive(false);
        lanceSelected.SetActive(true);

        catControll.currentSoldier = Soldier.Weapon.Lance;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Input1"))
        {
            SelectSword();
        }
        if (Input.GetButtonDown("Input2"))
        {
            SelectAxe();
        }
        if (Input.GetButtonDown("Input3"))
        {
            SelectLance();
        }
    }
}

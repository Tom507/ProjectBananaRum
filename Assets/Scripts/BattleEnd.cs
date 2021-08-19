using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleEnd : MonoBehaviour
{
    public GameObject WinScreen;
    public GameObject LooseScreen;

    public float endScreenDelay = 3f;

    public bool winLoose = false;

    PlayerManager pm;
    private void Start()
    {
        StartCoroutine(Utils.ExecuteAfterSeconds(0.1f, () =>
        {
            pm = PlayerManager.Instance;
            Soldier.playercount = pm.countSoldiers();
            Soldier.computerCount = pm.strengthOfBattleShip;
            Debug.Log("soldierCount::" + pm.countSoldiers());
            Debug.Log("shipstrength::" + pm.strengthOfBattleShip);
        }));

        levelStartTime = Time.time;
    }
    float levelStartTime = 0;

    bool winDetermined = false;
    private void Update()
    {
        if (winLoose)
        {
            //Debug.Log(Soldiers.computerCount);
            if(Soldier.computerCount <= 0 && Time.time > levelStartTime + 1 && !winDetermined)// Player Win
            {// Player Win
                winDetermined = true;
                Debug.Log("Player Wins");
                WinScreen.SetActive(true);
                pm.Gold += pm.battleShipReward;

                foreach(Soldier s in Soldier.allSoldiers)
                {
                    if(s.side == Soldier.Side.Player)
                    {
                        pm.addSoldier(s.weapon);
                    }
                }
                StartCoroutine(Utils.ExecuteAfterSeconds(endScreenDelay, () =>
                {
                    SceneManager.LoadScene("WorldScene");
                    CleanUp();
                }));
            }
            //Debug.Log(Soldiers.playercount <= 0 && Time.time > 1);
            if (Soldier.playercount <= 0 && Time.time > levelStartTime + 1 && !winDetermined)// Player Lost
            {// Player Lost
                winDetermined = true;
                Debug.Log("Player Looses");
                LooseScreen.SetActive(true);
                StartCoroutine(Utils.ExecuteAfterSeconds(endScreenDelay, () =>
                {
                    SceneManager.LoadScene("StartScreen");
                    CleanUp();
                }));
            }
        }
    }
    private void CleanUp()
    {
        Soldier.allSoldiers = new List<Soldier>();
        Soldier.computerCount = 0;
        Soldier.playercount = 0;
        winDetermined = false;
    }
}

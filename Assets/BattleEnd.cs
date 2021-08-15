using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleEnd : MonoBehaviour
{
    public GameObject WinScreen;
    public GameObject LooseScreen;

    PlayerManager pm;
    private void Start()
    {

        StartCoroutine(Utils.ExecuteAfterSeconds(0.1f, () =>
        {
            pm = PlayerManager.Instance;
            Soldiers.playercount = pm.countSoldiers();
            Soldiers.computerCount = pm.strengthOfBattleShip;
            Debug.Log("soldierCount::" + pm.countSoldiers());
            Debug.Log("shipstrength::" + pm.strengthOfBattleShip);
        }));
    }
    private void Update()
    {
        //Debug.Log(Soldiers.computerCount);
        if(Soldiers.computerCount <= 0 && Time.time > 1)
        {
            Debug.Log("Player Wins");
            WinScreen.SetActive(true);
            StartCoroutine(Utils.ExecuteAfterSeconds(1.5f, () =>
            {
                SceneManager.LoadScene("WorldScene");
            }));
        }
        //Debug.Log(Soldiers.playercount <= 0 && Time.time > 1);
        if (Soldiers.playercount <= 0 && Time.time > 1)
        {
            Debug.Log("Player Looses");
            LooseScreen.SetActive(false);
            StartCoroutine(Utils.ExecuteAfterSeconds(1.5f, () =>
            {
                SceneManager.LoadScene("WorldScene");
            }));
        }
    }
}

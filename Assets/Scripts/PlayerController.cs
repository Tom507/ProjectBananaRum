using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    NavMeshAgent agent;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public Vector3 input;
    private void Update()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        agent.SetDestination(transform.position + input * 5);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ship"))
        {
            PlayerManager pm = PlayerManager.Instance;
            EnemyShip ship = other.GetComponent<EnemyShip>();
            pm.strengthOfBattleShip = ship.Strength;
            pm.battleShipReward = ship.getReward();
            Debug.Log("Trigger Battle");
            SceneManager.LoadScene("BoardingScene");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShip : MonoBehaviour
{
    public int Strength = 10;
    public float waypointCadens = 15f;

    public GameObject spawnArea;

    float timeLastChange;

    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        spawnArea = GameObject.Find("EnemySpawner");
        Vector3 waypointPos = new Vector3(Random.Range(-1.0f, 1.0f) * (spawnArea.transform.localScale.x / 2), 0, Random.Range(-1.0f, 1.0f) * (spawnArea.transform.localScale.z / 2));
        agent.SetDestination(waypointPos);
    }

    public int getReward()
    {
        return (int)Strength * 3;
    }

    private void Update()
    {
        Vector3 waypointPos = new Vector3(Random.Range(-1.0f, 1.0f) * (spawnArea.transform.localScale.x / 2), 0, Random.Range(-1.0f, 1.0f) * (spawnArea.transform.localScale.z / 2));
        if (Time.time > timeLastChange + waypointCadens)
        {
            agent.SetDestination(waypointPos);
            timeLastChange = Time.time;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("col:: "+collision.gameObject.name);
        if(collision.gameObject.name == "Map" && Time.time < 1f)
        {
            Destroy(gameObject);
        }
    }
}

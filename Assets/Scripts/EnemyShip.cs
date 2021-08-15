using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShip : MonoBehaviour
{
    public float Strength = 10f;
    public float WaypointCadens = 15f;

    float timeLastChange;

    NavMeshAgent agent;

    public int getReward()
    {
        return (int)Strength * 3;
    }

    private void Update()
    {
        if(Time.time > timeLastChange + WaypointCadens)
        {
            
        }
    }
}

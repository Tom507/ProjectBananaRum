using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    public int SpawnAmount = 10;
    public GameObject spawnable;

    private void Start()
    {
        for (int i = 0; i < SpawnAmount; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-1.0f, 1.0f) * (transform.localScale.x / 2), Random.Range(-1.0f, 1.0f) * (transform.localScale.y / 2), Random.Range(-1.0f, 1.0f) * (transform.localScale.z / 2));
            GameObject go = Instantiate(spawnable, spawnPos, Quaternion.identity);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterduplicating : MonoBehaviour
{
    public GameObject Water;
    public int xAmount = 20;
    public int yAmount = 20;

    private void Start()
    {
        for(int x = 0; x<xAmount; x++)
        {
            for(int y = 0; y<yAmount; y++)
            {
                Instantiate(Water, transform.position + new Vector3(x * 10, 0, y * 10), Quaternion.identity, transform);
            }
        }
    }
}

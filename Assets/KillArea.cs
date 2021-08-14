using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Soldier"))
        {
            Soldiers.allSoldiers.Remove(other.GetComponent<Soldier>());
            Destroy(other.gameObject);
        }
    }
}

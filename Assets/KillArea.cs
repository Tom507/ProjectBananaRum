using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Soldier"))
        {
            Soldier s = other.GetComponent<Soldier>();
            Soldiers.allSoldiers.Remove(s);
            s.TakeDamage(200f);
        }
    }
}

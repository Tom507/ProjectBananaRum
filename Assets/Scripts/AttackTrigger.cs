using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    public List<Soldier> soldiersInProximity = new List<Soldier>();
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.parent != null && other.transform.parent.CompareTag("Soldier"))
        {
            soldiersInProximity.Add(other.GetComponentInParent<Soldier>());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.parent != null && other.transform.parent.gameObject.CompareTag("Soldier"))
        {
            soldiersInProximity.Remove(other.GetComponentInParent<Soldier>());
        }
    }
}

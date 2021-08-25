using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LodChanger : MonoBehaviour
{
    List<LODGroup> lODGroups = new List<LODGroup>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            try
            {
                LODGroup lod = transform.GetChild(i).GetComponent<LODGroup>();
                lODGroups.Add(lod);
            }
            catch
            {
                Debug.LogError(transform.GetChild(i).gameObject.name + ": has no LODgroup");
            }
        }
    }
}

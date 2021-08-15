using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    public GameObject catapultUi;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, catapultUi.transform.position.z);
    }
}

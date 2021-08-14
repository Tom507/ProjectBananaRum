using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    public GameObject catapultArrow;
    public float zPosFactor = 0.5f;
    public float xPosFactor = 0.5f;

    private Vector3 startPos;
    private void Start()
    {
        startPos = transform.position;
    }
    private void Update()
    {
        transform.position = new Vector3(startPos.x, startPos.y, startPos.z + catapultArrow.transform.position.z * zPosFactor);
    }
}

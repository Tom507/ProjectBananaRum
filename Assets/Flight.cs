using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flight : MonoBehaviour
{
    public bool isFlying = false;
    public Soldier s;
    public AnimationCurve curve;

    private void Start()
    {
        s = GetComponent<Soldier>();
        if (!isFlying)
        {
            enabled = false;
        }
    }

    public float flightTimeMax = 0.5f;
    public float flightDistanceMax = 90f;
    public float startDistance = -50f;
    public float flightHeight = 20f;

    private float catapultSpring;
    private float flightDistance;
    private Vector3 startPos;
    private float startTime;

    public void Initialize(float catSpring)
    {
        catapultSpring = catSpring;
        flightDistance = catapultSpring / 100 * flightDistanceMax;
        this.startPos = gameObject.transform.position;
        startTime = Time.time;
    }
    private void Update()
    {
        float timeSinceStart = Time.time - startTime;
        float flightprogress = flightTimeMax / timeSinceStart;
        transform.position = startPos + new Vector3(flightDistance * flightprogress, curve.Evaluate(flightprogress) * flightHeight, 0);
    }
}

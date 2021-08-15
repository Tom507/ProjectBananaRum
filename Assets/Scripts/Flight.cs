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

    public float flightTimeMax = 2f;
    public float flightDistanceMax = 90f;
    public float startDistance = -50f;
    public float flightHeight = 20f;

    private float catapultSpring;
    private float flightDistance;
    private float flightTime;
    private Vector3 startPos;
    private float startTime;

    public void Initialize(float catSpring)
    {
        flightTime = flightTimeMax * (catSpring/100);
        catapultSpring = catSpring;
        flightDistance = catapultSpring / 100 * flightDistanceMax;
        this.startPos = gameObject.transform.position;
        startTime = Time.time;
    }
    private void Update()
    {
        if (isFlying)
        {
            float timeSinceStart = Time.time - startTime;
            if (timeSinceStart > flightTime)
            {
                isFlying = false;
                GetComponent<Soldier>().enabled = true;
                return;
            }
            float flightprogress = Mathf.Clamp(1 - ((flightTime - timeSinceStart) / flightTime), 0, 1);
            //Debug.Log("Progress:: " + flightprogress);
            transform.position = startPos + new Vector3(flightDistance * flightprogress, curve.Evaluate(flightprogress) * flightHeight, 0);
        }
    }
}

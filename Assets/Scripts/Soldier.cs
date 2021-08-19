using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Soldier : MonoBehaviour
{
    public static List<Soldier> allSoldiers = new List<Soldier>();
    public static int computerCount = 0;
    public static int playercount = 0;

    public enum Side
    {
        Player,
        Computer
    }

    public enum Weapon
    {
        Sword,
        Axe,
        Lance
    }

    public enum State
    {
        Idle,
        Moving,
        Fighting
    }

    public float health = 100;
    public Side side = Side.Computer;
    public Weapon weapon;
    public State state;

    public Soldier target;
    public NavMeshAgent agent;

    private float timeLastAttack = 0f;
    private float attackDelay = 0.6f;

    public float sightDistance = 15f;

    public AttackTrigger attackTrigger;

    public bool randomiseWeapon = true;

    // Start is called before the first frame update
    void Awake()
    {
        attackTrigger = GetComponentInChildren<AttackTrigger>();
        agent = GetComponent<NavMeshAgent>();
        Soldier.allSoldiers.Add(this);
        if(randomiseWeapon) weapon = (Weapon)Random.Range(0, 3);
        //side = (Side)Random.Range(0, 2);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        GetComponentInChildren<Slider>().value = health;
        if(health <= 0)
        {
            //Debug.Log("damage");
            Soldier.allSoldiers.Remove(this);
            if(side == Side.Computer)
            {
                Soldier.computerCount--;
            }
            else
            {
                Soldier.playercount--;
            }
            Destroy(gameObject);
        }
    }

    public float DetermineDamage(Weapon attackWeapon, Weapon defendWeapon, float baseDamage = 34f, float multiplyer = 3)
    {
        switch (attackWeapon)
        {
            case Weapon.Sword:
                if(defendWeapon == Weapon.Lance)
                {
                    return baseDamage * multiplyer;
                }
                break;
            case Weapon.Axe:
                if (defendWeapon == Weapon.Sword)
                {
                    return baseDamage * multiplyer;
                }
                break;
            case Weapon.Lance:
                if (defendWeapon == Weapon.Axe)
                {
                    return baseDamage * multiplyer;
                }
                break;
        }
        return baseDamage;
    }

    

    private void OnTriggerEnter(Collider other) //transition to fight
    {
        if (other.gameObject.CompareTag("Soldier"))
        {
            Soldier enemy = other.GetComponent<Soldier>();
            if (enemy.side != side && state != State.Fighting)
            {
                state = State.Fighting;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Flight>().isFlying)
        {
            agent.enabled = false;
            this.enabled = false;
            return;
        }
        else
        {
            agent.enabled = true;
        }
        Soldier _target = target;
        State _state = state;
        switch (state)
        {
            case State.Idle:
                //search new enemy
                //start moving to enemy
                Soldier closest = getClosestEnemy();
                if (closest != null)
                {
                    if (!target)
                    {
                        target = closest;
                        agent.SetDestination(target.transform.position);
                        state = State.Moving;
                    }

                    if (target != closest)
                    {
                        target = closest;
                        agent.SetDestination(target.transform.position);
                        state = State.Moving;
                    }
                }
                break;

            case State.Moving:
                //search closest enemy
                //switch target if closest changes
                closest = getClosestEnemy();
                if(closest != null)
                {
                    target = closest;
                    agent.SetDestination(target.transform.position);

                    if ((target.transform.position - transform.position).magnitude < 1.5f)
                    {
                        state = State.Fighting;
                    }
                }
                else
                {
                    state = State.Idle;
                }
                break;

            case State.Fighting:
                agent.SetDestination(transform.position);
                if(Time.time > timeLastAttack + attackDelay )
                {
                    Attack();
                    timeLastAttack = Time.time;
                }
                if(!checkForEnemysClose())
                {
                    state = State.Idle;
                }
                //see if still alive
                break;
        }

        if(_target != target)
        {
            Debug.Log( gameObject.name + " new target:: " + target);
        }
        if(state != _state)
        {
            Debug.Log(gameObject.name + " new State:: " + state);
        }
    }

    bool checkForEnemysClose()
    {
        foreach(Soldier s in attackTrigger.soldiersInProximity)
        {
            if (s == null) attackTrigger.soldiersInProximity.Remove(s);
            if(s.side != side)
            {
                return true;
            }
        }
        return false;
    }

    public bool areaDamage = false;
    private void Attack()
    {
        if (areaDamage)
        {
            foreach (Soldier s in attackTrigger.soldiersInProximity)
            {
                if (s == null) attackTrigger.soldiersInProximity.Remove(s);
                if (s.side != side)
                {
                    s.TakeDamage(DetermineDamage(weapon, s.weapon));
                }
            }
        }
        else
        {
            target.TakeDamage(DetermineDamage(weapon, target.weapon));
        }
    }

    Soldier getClosestEnemy()
    {
        float minimalDistance = 100000000f;
        Soldier closest = null;
        foreach( Soldier s in Soldier.allSoldiers)
        {
            //if (s == null) Soldiers.allSoldiers.Remove(s);
            float distance = (transform.position - s.transform.position).magnitude;
            if (distance < minimalDistance && s.side != side && distance < sightDistance)
            {
                closest = s;
                minimalDistance = distance;
            }
        }
        return closest;
    }
}

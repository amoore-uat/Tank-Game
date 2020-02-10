using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEditor.VersionControl;
using UnityEngine;

[RequireComponent(typeof(TankData))]
public class SampleAIControllerFinal : MonoBehaviour
{
    public enum AIState { Chase, ChaseAndFire, CheckForFlee, Flee, Rest }

    public enum Personalities { Inky, Pinky, Blinky, Clay }

    public Personalities personality = Personalities.Inky;

    private TankData data;

    public GameObject player;

    public AIState aiState = AIState.Chase;
    private float stateEnterTime;
    private float healthRegenPerSecond = 25f;

    // Start is called before the first frame update
    void Start()
    {
        data = gameObject.GetComponent<TankData>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (personality)
        {
            case Personalities.Inky:
                Inky();
                break;
            case Personalities.Blinky:
                Blinky();
                break;
            case Personalities.Pinky:
                Pinky();
                break;
            case Personalities.Clay:
                Clay();
                break;
            default:
                break;
        }
    }

    private void Clay()
    {
        throw new NotImplementedException();
    }

    private void Pinky()
    {
        throw new NotImplementedException();
    }

    private void Blinky()
    {
        throw new NotImplementedException();
    }

    private bool playerIsInRange()
    {
        return true;
    }

    private void Chase(GameObject targetGameObject)
    {
        throw new NotImplementedException();
    }

    private void Inky()
    {
        switch (aiState)
        {
            case AIState.Chase:
                // Do the state behaviors
                Chase(player);
                // Check for transitions in order of priority
                if (data.health < (data.maxHealth * 0.5))
                {
                    ChangeState(AIState.CheckForFlee);
                }
                else if (playerIsInRange())
                {
                    ChangeState(AIState.ChaseAndFire);
                }
                break;
            case AIState.ChaseAndFire:
                // Do the state behaviors
                Chase(player);
                Shoot();
                // Check for transitions in the order of priority
                if (data.health < (data.maxHealth * 0.5))
                {
                    ChangeState(AIState.CheckForFlee);
                }
                else if (!playerIsInRange())
                {
                    ChangeState(AIState.Chase);
                }
                break;
            case AIState.CheckForFlee:
                if (playerIsInRange())
                {
                    ChangeState(AIState.Flee);
                }
                else
                {
                    ChangeState(AIState.Rest);
                }
                break;
            case AIState.Flee:
                Flee(player);
                // Wait 30 seconds then check for flee.
                if (Time.time >= (stateEnterTime + 30f))
                {
                    ChangeState(AIState.CheckForFlee);
                }
                break;
            case AIState.Rest:
                Rest();
                if (playerIsInRange())
                {
                    ChangeState(AIState.Flee);
                }
                else if (Mathf.Approximately(data.health, data.maxHealth))
                {
                    ChangeState(AIState.Chase);
                }
                break;
            default:
                break;
        }
    }

    private void Rest()
    {
        // Heal some hitpoints every second.
        data.health += healthRegenPerSecond * Time.deltaTime;
    }

    private void Flee(GameObject player)
    {
        throw new NotImplementedException();
    }

    private void Shoot()
    {
        throw new NotImplementedException();
    }

    public void ChangeState(AIState newState)
    {

        // Change our state
        aiState = newState;

        // save the time we changed states
        stateEnterTime = Time.time;
    }

}

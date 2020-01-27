using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankData))]
[RequireComponent(typeof(TankMotor))]
public class SampleAIController : MonoBehaviour
{
    public Transform[] waypoints;

    private TankData data;

    private TankMotor motor;

    private Transform tf;

    public int currentWaypoint = 0;

    public float closeEnough = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        data = gameObject.GetComponent<TankData>();
        motor = gameObject.GetComponent<TankMotor>();
        tf = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (motor.RotateTowards(waypoints[currentWaypoint].position, data.rotateSpeed))
        {
            // Do nothing!
        }
        else
        {
            // Move forward
            motor.Move(data.moveSpeed);
        }
        // If we are close to the waypoint,
        //if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < closeEnough)
        if (Vector3.SqrMagnitude(waypoints[currentWaypoint].position - tf.position) < (closeEnough * closeEnough))
        {

            // Advance to the next waypoint, if we are still in range
            if (currentWaypoint < waypoints.Length - 1)
            {
                currentWaypoint++;
            }
        }

    }
    
}

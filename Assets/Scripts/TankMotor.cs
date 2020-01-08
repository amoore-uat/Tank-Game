using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMotor : MonoBehaviour
{
    private CharacterController characterController;
    private Transform tf;
    private TankData data;

    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
        tf = gameObject.GetComponent<Transform>();
        data = gameObject.GetComponent<TankData>();
    }

    // Update is called once per frame
    void Update()
    {
        Move(data.moveSpeed);
        Rotate(data.rotateSpeed);
    }

    public void Move(float speed)
    {
        // Create a vector to hold our speed data
        Vector3 speedVector = tf.forward * speed;

        // Call SimpleMove() and send it our vector
        // Note that SimpleMove() will apply Time.deltaTime, and convert to meters per second for us!
        characterController.SimpleMove(speedVector);
    }

    public void Rotate(float speed)
    {
        // Create a vector to hold our rotation data
        Vector3 rotateVector = Vector3.up * speed * Time.deltaTime;

        // Now, rotate our tank by this value - we want to rotate in our local space (not in world space).
        tf.Rotate(rotateVector, Space.Self);
    }
}

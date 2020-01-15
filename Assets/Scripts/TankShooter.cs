using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class TankShooter : MonoBehaviour
{
    public GameObject cannonBall;

    public GameObject firePoint;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Shoot()
    {
        // Instantiate a bullet
        GameObject ourCannonBall;
        ourCannonBall = Instantiate(cannonBall, firePoint.transform);
        // Apply Force
        // ourCannonBall.SendMessage("ApplyForce",);
        // Tell the cannon ball how much damage it should do.
    }
}

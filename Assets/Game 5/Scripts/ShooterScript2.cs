﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript2 : MonoBehaviour
{
    

    //range for delay between shots
    public float shotsStartRangeLow;
    public float shotsStartRangeHigh;

    public float delayBeforeFirstShot = 5.0f;



  
    //if direction is true  move up, if direction is false  move down

    

    public float randomizer;

    private float projectileAmountRandomizer;
    public Rigidbody projectilePrefab;
    public float projectileSpeed;

    public float instantiationOffset;

    private float delayBetweenShots = 0f;

    public float increasingSpeed = 0.5f;

    private void Start()
    {
        projectileAmountRandomizer = Random.Range(3, 5);
        delayBetweenShots = Random.Range(shotsStartRangeLow, shotsStartRangeHigh);
        InvokeRepeating("TimeToShoot", delayBeforeFirstShot, delayBetweenShots);

    }

    void Update()
    {
        


    }

    void TimeToShoot()
    {
        print("Shooting");
        InvokeRepeating("Shoot", 1, 1);
        Invoke("CancelTheInvoke", projectileAmountRandomizer);
    }

    void Shoot()
    {

        for (int i = 0; i < 1; i++)
        {
            Rigidbody projectileInstance;
            projectileInstance = Instantiate(projectilePrefab, new Vector3(transform.position.x + instantiationOffset, transform.position.y, transform.position.z), transform.rotation) as Rigidbody;
            projectileInstance.AddForce(Vector3.right * projectileSpeed);

        }

    }

    void CancelTheInvoke()
    {
        CancelInvoke("Shoot");
    }
}

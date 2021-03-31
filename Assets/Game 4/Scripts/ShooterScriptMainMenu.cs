using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScriptMainMenu : MonoBehaviour
{

    public float shooterSpeed = 10.0f;

    public float highZBoundary;

    public float lowZBoundary;

    public bool direction;
    
    void Update()
    {
        if (transform.position.y > highZBoundary)
        {
            direction = false;
        }
        if (transform.position.y < lowZBoundary)
        {
            direction = true;
        }

        if (direction == true)
        {
            transform.Translate(Vector3.forward * shooterSpeed * Time.deltaTime);
        }

        if (direction == false)
        {
            transform.Translate(-Vector3.forward * shooterSpeed * Time.deltaTime);
        }
    }
}

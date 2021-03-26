using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    private int directionController = -1;
    public float speed = 5;
    public float xLimit = 5;
    void Update()
    {
        transform.Translate(Vector3.right * directionController * speed * Time.deltaTime);

        if (transform.position.x < -xLimit)
        {
            directionController = 1;
        }

        if (transform.position.x > xLimit)
        {
            directionController = -1;
        }

    }
}

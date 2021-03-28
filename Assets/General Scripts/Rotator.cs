using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed = 20;

    void Update()
    {
        transform.Rotate(transform.forward, speed * 10 * Time.deltaTime);
    }
}

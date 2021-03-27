using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public float horizontalSpeed = 10.0f;

    
    void Update()
    {
        transform.Translate(Vector3.left * horizontalSpeed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;

    private Quaternion startingRotation;

    private Vector3 startingPosition;

    private void Start()
    {
        startingPosition = transform.position;
        startingRotation = transform.rotation;
    }
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
        transform.rotation = startingRotation;

        if (transform.position.y < -3)
        {
            transform.position = startingPosition;
            transform.rotation = startingRotation;
        }
    }
}

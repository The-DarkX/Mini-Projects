using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMover : MonoBehaviour
{
    public float moveSpeed = 20f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = -Input.GetAxis("Vertical");

        transform.Rotate(Vector3.right, vertical * moveSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.up, horizontal * moveSpeed * Time.deltaTime, Space.World);

    }
}

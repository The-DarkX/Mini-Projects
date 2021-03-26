using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 30f;

    Vector3 lastVelocity;
    Vector3 moveDirection;

    float horizontalMove;

    Rigidbody rb;

    public int collisionCount = -1;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");

        moveDirection = new Vector3(horizontalMove, 0, 0);

        rb.AddForce(moveDirection * moveSpeed * 500 * Time.deltaTime);

        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        float speed = lastVelocity.magnitude;
        Vector3 direction = Vector3.Reflect(lastVelocity.normalized, collision.GetContact(0).normal);

        rb.velocity = direction * Mathf.Max(speed, 0);

        collisionCount++;
    }
}

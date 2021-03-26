using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMover : MonoBehaviour
{
    public float speed = 10;
    public bool canMove = true;

    Rigidbody rb;

	private void Start()
	{
        rb = GetComponent<Rigidbody>();
	}

	void Update()
    {
        if (canMove)
        {
            rb.AddForce(transform.forward * speed * Time.deltaTime);
        }
        else 
        {
            rb.velocity = Vector3.zero;
        }
    }

	private void OnCollisionEnter(Collision collision)
	{
        canMove = false;
        rb.isKinematic = true;

        if (collision.transform.CompareTag("Ground"))
        {
            transform.SetParent(collision.transform);
        }
        else if (collision.transform.CompareTag("Player")) 
        {
            GameManager.Restart();
        }
    }
}

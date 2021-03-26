using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFloater : MonoBehaviour
{
    public float movePower = 10f;

    public Material blueMat;
    public Material organgeMat;

    Vector3 moveDirection;

    bool isBlue = true;

    MeshRenderer mr;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mr = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (isBlue)
        {
            moveDirection = Vector3.up;
            mr.material = blueMat;
        }
        else 
        {
            moveDirection = Vector3.down;
            mr.material = organgeMat;
        }

        rb.AddForce(moveDirection * movePower * Time.deltaTime, ForceMode.Force);
    }

	private void OnMouseDown()
	{
        isBlue = !isBlue;
	}

	private void OnCollisionEnter(Collision collision)
	{
        if (collision.transform.CompareTag("Ground") && !isBlue) 
        {
            Destroy(gameObject);

        }
	}
}

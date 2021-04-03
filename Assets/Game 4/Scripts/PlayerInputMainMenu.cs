using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputMainMenu : MonoBehaviour
{

    

    public float xReset;
    public float yReset;
    public float xResetNeg;
    public float yResetNeg;

    public Rigidbody playerRb;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            playerRb.AddRelativeForce(Vector3.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerRb.AddRelativeForce(-Vector3.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            playerRb.AddRelativeForce(-Vector3.forward * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerRb.AddRelativeForce(Vector3.forward * speed * Time.deltaTime);
        }


        if (transform.position.y < yResetNeg)
        {
            transform.position = new Vector3(transform.position.x, yResetNeg, transform.position.z);
        }
        if (transform.position.y > yReset)
        {
            transform.position = new Vector3(transform.position.x, yReset, transform.position.z);
        }
        if (transform.position.x < xResetNeg)
        {
            transform.position = new Vector3(xResetNeg, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xReset)
        {
            transform.position = new Vector3(xReset, transform.position.y, transform.position.z);
        }
    }
}

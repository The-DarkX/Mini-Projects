using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    

    public float speed = 10.0f;

    public float zReset = 9.5f;
    public float xReset = 9.5f;

    private Vector3 startingPosition;

    private float score = 0;

    private void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-Vector3.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        }

        

        if(transform.position.z < -zReset)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zReset);
        }
        if (transform.position.z > zReset)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zReset);
        }
        if (transform.position.x < -xReset)
        {
            transform.position = new Vector3(-xReset, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xReset)
        {
            transform.position = new Vector3(xReset, transform.position.y, transform.position.z);
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            print("restart level");
        }

        if (collision.gameObject.tag == "Coin")
        {
            score++;
            print("restart level");
        }
    }
    
        
    

    void LevelReset()
    {
        transform.position = startingPosition;
    }
}

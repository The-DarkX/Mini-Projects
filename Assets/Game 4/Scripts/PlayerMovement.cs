using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float verticalSpeed = 10.0f;
    //verical Speed control

    public GameObject levelController;
    private Vector3 levelControllerStartingPosition;

    private Quaternion playerStartingRotation = new Quaternion (0,0,0,0);
    

    //player's rigidbody
    public Rigidbody player;

    private bool moveUp;
    private bool resetMomentum;

    public int score = 0;
    
    private void Start()
    {
        levelControllerStartingPosition = levelController.transform.position;
    }
    void Update()
    {
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        transform.rotation = new Quaternion(0, 0, 0, 0);
        
            if (moveUp)
            {
                player.AddForce(Vector3.forward * verticalSpeed * Time.deltaTime, ForceMode.VelocityChange);
            }
            else
            {
                player.AddForce(-Vector3.forward * verticalSpeed * Time.deltaTime, ForceMode.VelocityChange);
            }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            moveUp = !moveUp;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            LevelReset();
        }

        if(transform.position.z < -10)
        {
            LevelReset();
        }

        if(transform.position.z > 10)
        {
            LevelReset();
        }

       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            LevelReset();
        }

        if (collision.gameObject.tag == "Coin")
        {
            AddPoint();
        }


    }

    void LevelReset()
    {
        levelController.transform.position = levelControllerStartingPosition;

        transform.rotation = playerStartingRotation;
        transform.position = new Vector3 (0, 0, 0);

    }

    void AddPoint()
    {
        score += 1 ;
    }
}

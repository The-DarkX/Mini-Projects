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
    private void Start()
    {
        levelControllerStartingPosition = levelController.transform.position;
    }
    void Update()
    {

        if(moveUp)
        {
            player.AddForce(Vector3.up * verticalSpeed * Time.deltaTime, ForceMode.Impulse);
        }
        else
        {
            player.AddForce(Vector3.down * verticalSpeed * Time.deltaTime, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(moveUp);
            moveUp = !moveUp;
        }

       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            levelController.transform.position = levelControllerStartingPosition;

            transform.rotation = playerStartingRotation;
        }
    }
}

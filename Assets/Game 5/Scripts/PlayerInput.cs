using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInput : MonoBehaviour
{

    public Rigidbody playerRb;

    public float speed = 10.0f;

    public float zReset = 9.5f;
    public float xReset = 9.5f;

    private Vector3 startingPosition;

    private float score = 0;

    public TMP_Text scoreText;

    private float timer = 60;

    public TMP_Text timerText;

    public Color mediumWarningColor;
    public Color finalWarningColor;
    public Color firstWarningColor;
    private void Start()
    {
        startingPosition = transform.position;
        score = 0;
    }

    void Update()
    {
        timer -= 1.0f * Time.deltaTime;
        scoreText.text = score.ToString();
        timerText.text = Mathf.Round(timer).ToString();


        if (timer < 30)
        {
            if(timer >= 20)
            {
                timerText.color = firstWarningColor;
            }

        }

        if (timer < 20)
        {
            if(timer >= 10)
            {
                timerText.color = mediumWarningColor;
            }
        }

        if (timer < 10)
        {
            
                timerText.color = finalWarningColor;
            
        }



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
            playerRb.AddRelativeForce(Vector3.forward * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerRb.AddRelativeForce(-Vector3.forward * speed * Time.deltaTime);
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            score --;
            Destroy(collision.gameObject, 0f);
        }

        if (collision.gameObject.tag == "Coin")
        {
            score+=2;
            Destroy(collision.gameObject, 0f);
        }
    }  
}

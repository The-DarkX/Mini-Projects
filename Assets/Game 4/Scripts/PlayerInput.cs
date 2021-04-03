using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{

    public int escapeSceneDifference;
    public int levelEndSceneDifference;

    private AudioManager audioManager;

    public Rigidbody playerRb;

    public float speed = 10.0f;

    public float zReset = 9.5f;
    public float xReset = 9.5f;

    

    private Vector3 startingPosition;

    public float score = 0;

    public TMP_Text scoreText;

    private float timer = 60;

    public TMP_Text timerText;

    public Color mediumWarningColor;
    public Color finalWarningColor;
    public Color firstWarningColor;
    public Color groundColor;
    private void Start()
    {
        startingPosition = transform.position;
        score = 0;
        timer = 60;

        audioManager = AudioManager.instance;

        Invoke("StopMainMusic", 0.1f) ;


        audioManager.PlaySound("ActionBackground");
        
    }

    void Update()
    {

        

        if (timer <= 0)
        {
            LevelEnd();

        }


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

        if (timer < 10 && timer > 0) 
        {
            
                timerText.color = finalWarningColor;
            
        }

        if(score < 0)
        {
            score = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EscapeToMain();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            LevelReset();
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

        


        if (transform.position.z < -zReset)
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

        PlayerPrefs.SetFloat("finalScore", score);

        


    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            score --;
            Destroy(collision.gameObject, 0f);
            audioManager.PlaySound("ObstacleCollision");
            

        }

        if (collision.gameObject.tag == "Coin")
        {
            score+=2;
            Destroy(collision.gameObject, 0f);
            audioManager.PlaySound("PickUp");
        }
    }

    
    private void LevelEnd()
    {
        audioManager.StopSound("ActionBackground");
        audioManager.PlaySound("MenuBackground");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - levelEndSceneDifference);
        
        print("Level Ending");
    }

    private void EscapeToMain()
    {
        audioManager.StopSound("ActionBackground");
        audioManager.PlaySound("MenuBackground");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - escapeSceneDifference);
        
    }

    private void LevelReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void StopMainMusic()
    {
        audioManager.StopSound("MenuBackground");
    }

    
}

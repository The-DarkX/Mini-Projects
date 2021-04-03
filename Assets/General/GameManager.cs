using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text timerText;

    public int score;
    public float countdownTime = 10f;
    public bool useTimer = true;
    public bool canCount = true;

    float timer;

    AudioManager audioManager;

    public static GameManager instance { get; private set; }

	private void Awake()
	{
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
	private void Start()
	{
        audioManager = AudioManager.instance;

        audioManager.PlaySound("Background");

        DisplayScore();

        if (useTimer)
        {
            timerText.gameObject.SetActive(true);
            canCount = true;
        }
        else 
        {
            timerText.gameObject.SetActive(false);
            canCount = false;
        }

        timer = countdownTime;
	}

	private void Update()
	{
        if (useTimer) 
        {
            if (timer > 0.0f && canCount)
            {
                timer -= Time.deltaTime;

                float minutes = Mathf.Floor(timer / 60);
                float seconds = timer % 60;

                timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
            }
            else if (timer <= 0.0f) 
            {
                canCount = false;
                timerText.text = "0:00";
                timer = 0.0f;
                GameOver();
            }
        }
	}

    public void ResetTimer() 
    {
        canCount = false;
        timer = countdownTime;
    }

	public void Restart() 
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }

    public void GameOver()
    {
        canCount = false;
        print("Game Over");
        audioManager.StopSound("Background");
    }

    public void DisplayScore()
    {
        scoreText.text = score.ToString();
    }

    public void AddScore(int scoreIncrement) 
    {
        score += scoreIncrement;
    }

    public void AddScore(int minScoreIncrement, int maxScoreIncrement)
    {
        score += Random.Range(minScoreIncrement, maxScoreIncrement);
    }

    public void SubtractScore(int scoreDecrement) 
    {
        if (score - scoreDecrement <= 0)
        {
            score = 0;
        }
        else
        {
            score -= scoreDecrement;
        }
    }

    public void LoadScene(int index) 
    {
        SceneManager.LoadScene(index);
    }
}

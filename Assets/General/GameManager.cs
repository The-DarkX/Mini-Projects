using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverCanvas;

    public TMP_Text scoreText;
    public TMP_Text timerText;

    public int score;
    public float countdownTime = 10f;
    public bool useTimer = true;
    public bool canCount = true;
    public bool isGameRunning = false;

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
        GameOverCanvas.SetActive(false);

        isGameRunning = true;

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
        if (useTimer && isGameRunning) 
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
        isGameRunning = false;
        canCount = false;
        audioManager.StopSound("Background");
        audioManager.PlaySound("GameOver");

        GameOverCanvas.SetActive(true);
    }

    public void DisplayScore()
    {
        scoreText.text = score.ToString();
    }

    public void AddScore(int scoreIncrement) 
    {
        int newScore = score + scoreIncrement;

        if (newScore > PlayerPrefs.GetInt("Game2_HighScore", 0)) 
        {
            PlayerPrefs.SetInt("Game2_HighScore", newScore);
        }
        score = newScore;
    }

    public void AddScore(int minScoreIncrement, int maxScoreIncrement)
    {
        int newScore = Random.Range(minScoreIncrement, maxScoreIncrement);

        if (newScore > PlayerPrefs.GetInt("Game2_HighScore", 0))
        {
            PlayerPrefs.SetInt("Game2_HighScore", newScore);
        }

        score = newScore;
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

    public void Quit() 
    {
        Application.Quit();
    }
}

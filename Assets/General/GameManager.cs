using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;

    public int score;

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
            DontDestroyOnLoad(this);
        }
    }
	private void Start()
	{
        audioManager = AudioManager.instance;

        audioManager.PlaySound("Background");

        DisplayScore();
	}

	public void Restart() 
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
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
            score = 0;
    }

    public void LoadScene(int index) 
    {
        SceneManager.LoadScene(index);
    }
}

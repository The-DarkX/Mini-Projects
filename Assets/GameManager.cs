using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{    
    public static void Restart() 
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }

    public static void DisplayScore(Text scoreText, int score) 
    {
        scoreText.text = score.ToString();
    }
}

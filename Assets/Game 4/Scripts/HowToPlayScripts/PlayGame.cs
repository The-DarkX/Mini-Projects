using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = AudioManager.instance;
    }
    public void StartNewGame()
    {
        audioManager.PlaySound("ButtonClick");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    public void GoToMainMenu()
    {
        audioManager.PlaySound("ButtonClick");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void StartNewGameFromPause()
    {
        audioManager.PlaySound("ButtonClick");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        
    }

    public void GoToMainMenuFromPause()
    {
        audioManager.PlaySound("ButtonClick");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuStartScript : MonoBehaviour
{

    private AudioManager audioManager;
    private void Start()
    {
        audioManager = AudioManager.instance;

        audioManager.PlaySound("MenuBackground");
    }
    public void StartGame()
    {

        audioManager.PlaySound("ButtonClick");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

        audioManager.StopSound("MenuBackground");
    }

    public void LoadHowToPlay()
    {

        audioManager.PlaySound("ButtonClick");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        audioManager.StopSound("MenuBackground");
    }
}

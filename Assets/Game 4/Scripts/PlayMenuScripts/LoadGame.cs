using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = AudioManager.instance;
    }
    public void LoadEasyScene()
    {

        audioManager.PlaySound("ButtonClick");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

        print("Click detected");
    }

    public void LoadMediumScene()
    {
        audioManager.PlaySound("ButtonClick");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);

    }

    public void LoadHardScene()
    {
        audioManager.PlaySound("ButtonClick");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);

    }

    public void LoadExtremeScene()
    {
        audioManager.PlaySound("ButtonClick");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);

    }

    public void LoadMainfromPlay()
    {
        audioManager.PlaySound("ButtonClick");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);

    }
}

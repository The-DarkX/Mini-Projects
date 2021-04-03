using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
   public void LoadEasyScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

        print("Click detected");
    }

    public void LoadMediumScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);

    }

    public void LoadHardScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);

    }

    public void LoadExtremeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);

    }

    public void LoadMainfromPlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);

    }
}

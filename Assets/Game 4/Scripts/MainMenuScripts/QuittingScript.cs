using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuittingScript : MonoBehaviour
{

    private AudioManager audioManager;
    private void Start()
    {
        audioManager = AudioManager.instance;
    }
    public void Quit()
    {
        audioManager.PlaySound("ButtonClick");
        Application.Quit();
    }
}

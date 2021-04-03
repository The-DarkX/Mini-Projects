using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{

    

    public TMP_Text scoreValue;

    private float scoreReference;
    void Start()
    {
        
            
        scoreReference = PlayerPrefs.GetFloat("finalScore");

        scoreValue.text = scoreReference.ToString();
    }
    
}

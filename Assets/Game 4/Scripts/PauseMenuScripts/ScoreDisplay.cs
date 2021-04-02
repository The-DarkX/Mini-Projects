using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{

    private PlayerInput score;

    public TMP_Text scoreValue;

    private float scoreReference;
    void Start()
    {
        
        scoreValue.text = scoreReference.ToString();
    }
    
}

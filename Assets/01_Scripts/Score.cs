using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public Text prizeText;

    // Start is called before the first frame update
    void Start()
    {
        string score = "";
        score = PlayerPrefs.GetString("Score");
        scoreText.text = score;

        if (Int32.Parse(score) >= 50 && Int32.Parse(score) < 100)
        {
            prizeText.text = "You won 5% Discount!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

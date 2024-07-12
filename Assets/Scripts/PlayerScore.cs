using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScore;
    int scoreIncreament = 0;
    void Update() 
    {
        scoreText.text = scoreIncreament.ToString();
        finalScore.text = "FINAL SCORE: " + scoreIncreament.ToString();  
    }

    public void UpdateScore()
    {
        scoreIncreament += 1;        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    
    public TextMeshProUGUI scoreText;

    public static int flagValue = 5;

    public static int score = 0;
    public static int highScore = 0;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
       scoreText.text = "Score:  " + score.ToString();
    }

    public void AddPoint()
    {
        score += flagValue;
        scoreText.text = "Score:  " + score.ToString();
        if (highScore < score)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}

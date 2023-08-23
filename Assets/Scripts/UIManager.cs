using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private void Update()
    {
        scoreText.text = "Skor   " + ScoreManager.score.ToString();
        ScoreManager.highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "En Yüksek Skor   " + ScoreManager.highScore;
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
        ScoreManager.score = 0;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        ScoreManager.score = 0;
    }



}

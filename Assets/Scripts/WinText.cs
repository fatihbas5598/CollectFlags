using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinText : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private void Update()
    {
        scoreText.text = "Puanın  " + ScoreManager.score.ToString();
    }

    public void NextLevel2()
    {
        SceneManager.LoadScene(2);
        int scorePoint = ScoreManager.score;
        scoreText.text = scorePoint.ToString(); 
    }

    public void NextLevel3()
    {
        SceneManager.LoadScene(3);
        int scorePoint = ScoreManager.score;
        scoreText.text = scorePoint.ToString();
    }

    public void NextLevel4()
    {
        SceneManager.LoadScene(4);
        int scorePoint = ScoreManager.score;
        scoreText.text = scorePoint.ToString();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}

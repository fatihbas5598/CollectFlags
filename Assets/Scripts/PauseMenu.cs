using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    LevelManager levelManagerScript;
    
    public static bool isPaused;

    public GameObject canvasPause;

    private void Awake()
    {
        levelManagerScript = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        canvasPause.SetActive(false);
        Time.timeScale = 1;
        levelManagerScript.canMove = true;
        isPaused = false;
    }

    public void Pause()
    {
        canvasPause.SetActive(true);
        Time.timeScale = 0;
        levelManagerScript.canMove = false;
        isPaused = true;
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        levelManagerScript.canMove = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealt : MonoBehaviour
{
    UIManager uiManagerScript;
    Delay delayScript;

    [SerializeField] Image[] playerLives;
    [SerializeField] private int playerLife = 3;

    void Start()
    {
        uiManagerScript = GameObject.Find("UIManager").GetComponent<UIManager>();
        delayScript = GameObject.Find("LevelManager").GetComponent<Delay>();
    }

    public void Lives()
    {
        playerLife--;
        Destroy(playerLives[playerLife]);

        if (playerLife < 1)
        {
            delayScript.delayTime = false;
            uiManagerScript.GetComponent<Canvas>().enabled = true;
        }
    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    SoundManager soundManagerScript;
    LevelManager LevelManagerScript;
    WinText winScreenTextScript;
    public BoxCollider2D boxCollider;

    private void Awake()
    {
        LevelManagerScript = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        winScreenTextScript = GameObject.Find("WinCanvas").GetComponent<WinText>();
        soundManagerScript = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && LevelManagerScript.canWin)
        {
            winScreenTextScript.GetComponent<Canvas>().enabled = true;
            soundManagerScript.WinSound();
            LevelManagerScript.canWin = false;
            collision.gameObject.SetActive(false);
        }
    }
}

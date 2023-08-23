using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fries : MonoBehaviour
{
    LevelManager LevelManagerScript;
    SoundManager soundManagerScript;

    private void Awake()
    {
        LevelManagerScript = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        soundManagerScript = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    private void Start()
    {
        LevelManager.Instance.GetCurrentFries().Add(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            LevelManager.Instance.GetCurrentFries().Remove(this);
            Destroy(gameObject);
            LevelManagerScript.friesBool = true;
            soundManagerScript.DestroyFries();
            LevelManagerScript.count++;
            ScoreManager.instance.AddPoint();
        }
    }
}

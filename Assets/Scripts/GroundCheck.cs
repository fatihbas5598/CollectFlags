using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    SoundManager soundManagerScript;


    void Start()
    {
        soundManagerScript = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FeetPosition"))
        {
            soundManagerScript.Land();
        }
    }

}

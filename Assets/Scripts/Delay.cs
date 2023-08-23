using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour
{

    public bool delayTime = true;

    public void DelayNewTime()
    {
        StartCoroutine(DelayTime());
    }
    IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(0.5f);
        LevelManager.Instance.SpawnPlayer();
    }
}

using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using UnityEngine;

public class Gun : MonoBehaviour
{
    Vector2 direction;
    Vector2 target;



    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            target = player.transform.position;

            direction = target - (Vector2)transform.position;

            transform.right = -direction;
        }
    }
}
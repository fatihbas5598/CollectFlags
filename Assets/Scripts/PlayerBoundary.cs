using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundary : MonoBehaviour
{
    void Update()
    {
        if(transform.position.x < -8.24f)
        {
            transform.position = new Vector3(-8.24f, transform.position.y, transform.position.z);
        }

        if (transform.position.x > 8.24f)
        {
            transform.position = new Vector3(8.24f, transform.position.y, transform.position.z);
        }
    }
}

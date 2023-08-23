using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detected : MonoBehaviour
{
    Turret[] turretScript;
    [SerializeField] float range;

    private void Awake()
    {
        turretScript = GameObject.FindObjectsOfType<Turret>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach(var turret in turretScript)
            {
                turret.isClose = true;
                turret.Fire();
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (var turret in turretScript)
            {
                turret.isClose = false;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

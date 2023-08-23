using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform enemySpawnPoint;
    [SerializeField] float enemySpeed;
    bool moveEnemy = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            moveEnemy = true;
        }
    }

    private void FixedUpdate()
    {
        MoveEnemy();
    }


    private void MoveEnemy()
    {
        if (moveEnemy)
        {
            for (int i = 0; i < 1; i++)
            {
                SpawnEnemy();
                moveEnemy = false;
            }         
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, enemySpawnPoint.position, enemyPrefab.transform.rotation);
    }


}

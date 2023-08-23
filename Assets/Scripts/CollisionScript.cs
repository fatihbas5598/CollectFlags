using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    LevelManager levelManagerScript;
    SoundManager soundManagerScript;
    UIManager uiManagerScript;
    PlayerHealt playerHealtScript;
    Delay delayScript;

    [SerializeField] float enemyAttackSpeed;
    [SerializeField] private float leftScreenBounds = -10f;
    bool isAttacking = false;

    private void Awake()
    {
        levelManagerScript = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        soundManagerScript = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        uiManagerScript = GameObject.Find("UIManager").GetComponent <UIManager>();
        playerHealtScript = GameObject.Find("LevelManager").GetComponent<PlayerHealt>();
        delayScript = GameObject.Find("LevelManager").GetComponent<Delay>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy killed player");
            Destroy(collision.gameObject);
            soundManagerScript.DeathByEnemy();
            playerHealtScript.Lives();
            if (delayScript.delayTime == true)
            {
                delayScript.DelayNewTime();
            }
        }
    }

    private void FixedUpdate()
    {
        AttackEnemy();
        DestroyEnemy();
    }

    void AttackEnemy()
    {
        transform.Translate(-1 * enemyAttackSpeed * Time.deltaTime, 0, 0);

        while (!isAttacking)
        {
            soundManagerScript.EnemyAttack();
            isAttacking = true;
        }
    }

    void DestroyEnemy()
    {
        if (transform.position.x < leftScreenBounds)
        {
            Destroy(gameObject);
        }
    }

}
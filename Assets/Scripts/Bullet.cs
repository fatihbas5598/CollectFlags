using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    SoundManager soundManagerScript;

    PlayerHealt playerHealtScript;
    Delay delayScript;

    [SerializeField] float bulletSpeed;
    [SerializeField] ParticleSystem groundParticle;
    [SerializeField] ParticleSystem playerDeathParticle;

    Rigidbody2D rb;

    private void Awake()
    {
        soundManagerScript = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        playerHealtScript = GameObject.Find("LevelManager").GetComponent<PlayerHealt>();
        delayScript = GameObject.Find("LevelManager").GetComponent<Delay>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        rb.velocity = -transform.right * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
  

        if (collision.gameObject.CompareTag("Ground"))
        {
            Instantiate(groundParticle, transform.position, Quaternion.identity);
            soundManagerScript.GroundParticleSound();
        }

        if (collision.gameObject.CompareTag("Door"))
        {
            Instantiate(groundParticle, transform.position, Quaternion.identity);
            soundManagerScript.GroundParticleSound();
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            soundManagerScript.DeathByBullet();
            Instantiate(playerDeathParticle, transform.position, Quaternion.identity);
            collision.gameObject.SetActive(false);
            playerHealtScript.Lives();

            if (delayScript.delayTime)
            {
                delayScript.DelayNewTime();
            }
        }

        PoolManager.Instance.DespawnBullet(this.gameObject);
    }
}

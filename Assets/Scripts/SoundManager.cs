using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] private AudioClip jump;
    [SerializeField] private AudioClip land;
    [SerializeField] private AudioClip deathByEnemy;
    [SerializeField] private AudioClip deathByFall;
    [SerializeField] private AudioClip enemyAttack;
    [SerializeField] private AudioClip popFries;
    [SerializeField] private AudioClip destroyFries;
    [SerializeField] private AudioClip winSound;
    [SerializeField] private AudioClip runDoor;
    [SerializeField] private AudioClip hitGround;
    [SerializeField] private AudioClip shot;
    [SerializeField] private AudioClip deathByBullet;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Jump()
    {
        audioSource.PlayOneShot(jump);
    }

    public void Land()
    {
        audioSource.PlayOneShot(land);
    }

    public void DeathByEnemy()
    {
        audioSource.PlayOneShot(deathByEnemy);
    }

    public void DeathByFall()
    {
        audioSource.PlayOneShot(deathByFall);
    }

    public void EnemyAttack()
    {
        audioSource.PlayOneShot(enemyAttack);
    }

    public void PopFries()
    {
        audioSource.PlayOneShot(popFries);
    }

    public void DestroyFries()
    {
        audioSource.PlayOneShot(destroyFries);
    }

    public void WinSound()
    {
        audioSource.PlayOneShot(winSound);
    }

    public void RunDoor()
    {
        audioSource.PlayOneShot(runDoor);
    }

    public void GroundParticleSound()
    {
        audioSource.PlayOneShot(hitGround);
    }

    public void Shot()
    {
        audioSource.PlayOneShot(shot);
    }

    public void DeathByBullet()
    {
        audioSource.PlayOneShot(deathByBullet);
    }
}

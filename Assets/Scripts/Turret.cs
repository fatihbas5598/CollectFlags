using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Turret : MonoBehaviour
{
    SoundManager soundManagerScript;
    
    [SerializeField] private Transform bulletPoint;
    [SerializeField] GameObject gunLight;
    [SerializeField] ParticleSystem muzzleParticle;
    [SerializeField] Transform muzzlePos;
    [SerializeField] float fireRate;
    [SerializeField] private float detectDistance = 5f;
    float nextfire = 0;
    public bool isClose;

    private void Awake()
    {
        soundManagerScript = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    void Update()
    {
        GunLight();
        DetectPlayer();
    }

    public void Fire()
    {
        if (Time.time > nextfire)
        {
            nextfire = Time.time + 1 / fireRate;
            soundManagerScript.Shot();
            var muzzleParticle = PoolManager.Instance.SpawnMuzzleParticle();
            muzzleParticle.transform.position = muzzlePos.transform.position;
            muzzleParticle.transform.rotation = Quaternion.identity;
            CreateBullet();
        }
    }

    void GunLight()
    {
        if (isClose)
        {
            gunLight.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            gunLight.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    void CreateBullet()
    {
        GameObject bullet = PoolManager.Instance.SpawnBullet();
            
            if (bullet != null )
            {
                bullet.transform.position = bulletPoint.position;
                bullet.transform.rotation = bulletPoint.rotation;   

            }
    }
    private void DetectPlayer() 
    { 
        var player = FindObjectOfType<PlayerController>();
        var levelManager = FindObjectOfType<LevelManager>();

        if(levelManager.GetCurrentFries().Any(fries => Vector3.Distance(player.transform.position, fries.transform.position) <= detectDistance))
        {
            isClose = true;
            Fire();
        }
        else
        {
            isClose = false;
        }
    }
}

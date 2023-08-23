using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    //public static BulletPool instance;

    //int amountObjects = 20;

    //private List<GameObject> pooledObjects = new List<GameObject>();

    //[SerializeField] GameObject bulletPrefab;


    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //    }
    //}


    //private void Start()
    //{
    //    for (int i = 0; i < amountObjects; i++)
    //    {
    //        GameObject bullet = Instantiate(bulletPrefab);
    //        bullet.SetActive(false);
    //        pooledObjects.Add(bullet);
    //    }
    //}

    //public GameObject GetObjectFromPool()
    //{
    //    for (int i = 0; i < pooledObjects.Count; i++)
    //    {
    //        if (!pooledObjects[i].activeInHierarchy)
    //        {
    //            return pooledObjects[i];
    //        }
    //    }

    //    return null;
    //}
}

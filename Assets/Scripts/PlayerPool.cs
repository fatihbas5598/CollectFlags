using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPool : MonoBehaviour
{
    public static PlayerPool instance;

    int amountObjects = 1;

    List<GameObject> pooledObjects = new List<GameObject>();

    [SerializeField] GameObject playerPrefab;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    private void Start()
    {
        for (int i = 0; i < amountObjects; i++)
        {
            GameObject player = Instantiate(playerPrefab);
            player.SetActive(true);
            pooledObjects.Add(player);
        }
    }

    public GameObject GetObjectFromPool()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        return null;
    }
}

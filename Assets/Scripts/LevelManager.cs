using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : LocalSingleton<LevelManager>
{
    SoundManager soundManagerScript;
    Door doorScript;
    LockStatus lockStatusScript;

    [SerializeField] GameObject playerPrefab;
    [SerializeField] Transform playerSpawnPoint;
    [SerializeField] GameObject friesPrefab;
    public int count;
    public bool friesBool;
    public bool canWin;
    public bool canMove = true;
    private List<Fries> _currentFries = new List<Fries>();

 
#pragma warning disable CS0114 // Üye devralınmış üyeyi gizler; geçersiz kılma anahtar sözcüğü eksik
    private void Awake()
#pragma warning restore CS0114 // Üye devralınmış üyeyi gizler; geçersiz kılma anahtar sözcüğü eksik
    {
        soundManagerScript = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        doorScript = GameObject.Find("Door").GetComponent <Door>();
        lockStatusScript = GameObject.Find("Door/LockStatus").GetComponent<LockStatus>();
        lockStatusScript.GetComponent<SpriteRenderer>().sprite = lockStatusScript.lockUnlock[1];
    }

    private void Start()
    {
        StartCoroutine(DelayFries());
        SpawnPlayer();
    }

    private void Update()
    {
        if (friesBool)
        {
            StartCoroutine(DelayFries());
            friesBool = false;
        }
    }

    public void SpawnPlayer()
    {
        GameObject player = PlayerPool.instance.GetObjectFromPool();
        if (player != null)
        {
            player.transform.position = playerSpawnPoint.position;
            player.SetActive(true);
        }
    }
     
    public void SpawnFries()
    {
        Vector3 firstPos = new Vector3(Random.Range(-8.5f, 6.5f), -3.65f, 0);
        Vector3 secondPos = new Vector3(Random.Range(-8.5f, 6.5f), -0.2f, 0);

        int randomSpawner = Random.Range(1, 3);

        var fries = Instantiate(friesPrefab, randomSpawner == 1 ? firstPos : secondPos, Quaternion.identity).GetComponent<Fries>();
        //_currentFries.Add(fries);
    }


    IEnumerator DelayFries()
    {
        if (count == 10)
        {
            canWin = true;
            lockStatusScript.GetComponent<SpriteRenderer>().sprite = lockStatusScript.lockUnlock[0];
            doorScript.boxCollider.enabled = false;
            soundManagerScript.RunDoor();
        }
        
        yield return new WaitForSeconds(1.5f);
        
        if (count < 10)
        {
            SpawnFries();
            soundManagerScript.PopFries();
        }

    }

    public List<Fries> GetCurrentFries()
    {
        return _currentFries;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] private bool _isMuzzleParticle = false;


    IEnumerator Start()
    {
        yield return new WaitForSeconds(time);

        if(_isMuzzleParticle)
        {
            PoolManager.Instance.DespawnMuzzleParticle(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
       
    }
}

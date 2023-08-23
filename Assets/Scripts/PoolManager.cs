using System.Collections;
using System.Collections.Generic;
using Lean.Pool;
using UnityEngine;

public class PoolManager : LocalSingleton<PoolManager>
{
    [SerializeField] private LeanGameObjectPool _bulletPool;
    [SerializeField] private LeanGameObjectPool _muzzleParticlePool;

    public GameObject SpawnBullet()
    {
        GameObject result = null;
        _bulletPool.TrySpawn(ref result);
        return result;
    }

    public GameObject SpawnMuzzleParticle()
    {
        GameObject result = null;
        _muzzleParticlePool.TrySpawn(ref result);
        return result;
    }
    public void DespawnBullet(GameObject bullet)
    {
        _bulletPool.Despawn(bullet);
    }

    public void DespawnMuzzleParticle(GameObject muzzleParticle)
    {
        _muzzleParticlePool.Despawn(muzzleParticle);
    }


}

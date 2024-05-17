using System.Collections;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private float _spawnDelay;

    public void StartShoot(BulletSpawner _bulletSpawner)
    {
        StartCoroutine(GenerateBullets(_bulletSpawner));
    }


    private IEnumerator GenerateBullets(BulletSpawner _bulletSpawner)
    {
        var wait = new WaitForSeconds(_spawnDelay);

        while (enabled)
        {
            _bulletSpawner.SpawnObject(transform.position);
            yield return wait;
        }
    }
}

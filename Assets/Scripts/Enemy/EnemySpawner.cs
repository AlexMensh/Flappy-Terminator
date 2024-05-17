using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Enemy _prefab;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private BulletSpawner _bulletSpawner;

    private ObjectPooler<Enemy> _pool;

    private void Awake()
    {
        _pool = new ObjectPooler<Enemy>(_prefab, _container);
    }

    private void Start()
    {
        StartCoroutine(GenerateEnemies());
    }

    public void RemoveObject(Enemy enemy)
    {
        _pool.PutObject(enemy);
    }

    private IEnumerator GenerateEnemies()
    {
        var wait = new WaitForSeconds(_spawnDelay);

        while (enabled)
        {
            SpawnObject();
            yield return wait;
        }
    }

    private void SpawnObject()
    {
        float spawnPositionY = Random.Range(_upperBound, _lowerBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        var enemy = _pool.GetObject();

        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawnPoint;
        enemy.gameObject.GetComponent<EnemyShoot>().StartShoot(_bulletSpawner);
    }
}
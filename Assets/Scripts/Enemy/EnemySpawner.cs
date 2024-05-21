using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Enemy _prefab;
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;

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
        enemy.OnDeath -= HandleEnemyDeath;
        _pool.PutObject(enemy);
    }

    public void Reset()
    {
        _pool.Reset();
    }
    private void HandleEnemyDeath(Enemy enemy)
    {
        _scoreCounter.Add();
        RemoveObject(enemy);
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
        enemy.StartShoot(_bulletSpawner);
        enemy.OnDeath += HandleEnemyDeath;
    }
}
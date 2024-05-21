using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Bullet _prefab;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private Vector3 _spawnOffset;

    private ObjectPooler<Bullet> _pool;

    private void Awake()
    {
        _pool = new ObjectPooler<Bullet>(_prefab, _container);
    }

    public void RemoveObject(Bullet bullet)
    {
        _pool.PutObject(bullet);
    }

    public void Reset()
    {
        _pool.Reset();
    }

    public void SpawnObject(Vector3 position)
    {
        var bullet = _pool.GetObject();

        bullet.gameObject.SetActive(true);
        bullet.transform.position = position + _spawnOffset;
        bullet.SetSpeed(_bulletSpeed);
    }
}
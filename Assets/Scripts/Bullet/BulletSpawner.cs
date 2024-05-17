using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Bullet _prefab;
    [SerializeField] private bool _isPlayer;
    [SerializeField] private float _bulletSpeed;

    private ObjectPooler<Bullet> _pool;

    private void Awake()
    {
        _pool = new ObjectPooler<Bullet>(_prefab, _container);
    }

    public void RemoveObject(Bullet bullet)
    {
        _pool.PutObject(bullet);
    }

    public void SpawnObject(Vector3 position)
    {
        var bullet = _pool.GetObject();

        if (_isPlayer == false)
        {
            bullet.ReverseMovement();
        }

        bullet.gameObject.SetActive(true);
        bullet.transform.position = position;
        bullet.SetSpeed(_bulletSpeed);
    }
}
using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private BulletSpawner _bulletSpawner;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _enemySpawner.RemoveObject(enemy);
        }
        else if (other.TryGetComponent(out Bullet bullet))
        {
            _bulletSpawner.RemoveObject(bullet);
        }
    }
}
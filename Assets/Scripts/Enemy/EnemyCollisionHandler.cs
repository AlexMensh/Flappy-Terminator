using System;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyCollisionHandler : MonoBehaviour
{
    private EnemySpawner _spawner;
    private ScoreCounter _counter;

    public event Action<Bullet, EnemySpawner> CollisionDetected;

    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    public void SetSpawner(EnemySpawner spawner)
    {
        _spawner = spawner;
    }

    public void SetCounter(ScoreCounter scoreCounter)
    {
        _counter = scoreCounter;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Bullet bullet))
        {
            _counter.Add();
            CollisionDetected?.Invoke(bullet, _spawner);
        }
    }
}
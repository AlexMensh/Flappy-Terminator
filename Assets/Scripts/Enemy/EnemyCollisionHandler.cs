using System;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyCollisionHandler : MonoBehaviour
{
    public event Action<Bullet> CollisionDetected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Bullet bullet))
        {
            CollisionDetected?.Invoke(bullet);
        }
    }
}
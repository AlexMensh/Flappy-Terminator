using System;
using UnityEngine;

[RequireComponent(typeof(EnemyCollisionHandler), typeof(EnemyShoot))]
public class Enemy : MonoBehaviour, IInteractable
{
    private EnemyCollisionHandler _collisionHandler;
    private EnemyShoot _enemyShoot;

    public event Action<Enemy> OnDeath;

    private void Awake()
    {
        _collisionHandler = GetComponent<EnemyCollisionHandler>();
        _enemyShoot = GetComponent<EnemyShoot>();
    }

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= ProcessCollision;
    }

    public void StartShoot(BulletSpawner bulletSpawner)
    {
        _enemyShoot.StartShoot(bulletSpawner);
    }

    private void ProcessCollision(Bullet bullet)
    {
        if (bullet.TryGetComponent(out Bullet bulletItem))
        {
            if (bulletItem.GetAmmoOwner() == false)
            {
                OnDeath?.Invoke(this);
            }
        }
    }
}
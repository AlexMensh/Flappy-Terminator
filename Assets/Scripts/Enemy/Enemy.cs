using UnityEngine;

public class Enemy : MonoBehaviour, IInteractable 
{
    private EnemyCollisionHandler _handler;
    private void Awake()
    {
        _handler = GetComponent<EnemyCollisionHandler>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    private void ProcessCollision(Bullet bullet, EnemySpawner spawner)
    {
        if (bullet.GetComponent<Bullet>().GetReverseStatus() == false)
        {
            spawner.RemoveObject(this);
        }
    }
}

using UnityEngine;

public class Enemy : MonoBehaviour, IInteractable
{
    private EnemyCollisionHandler _handler;
    private ScoreCounter _counter;

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

    public void SetCounter(ScoreCounter scoreCounter)
    {
        _counter = scoreCounter;
    }

    private void ProcessCollision(Bullet bullet, EnemySpawner spawner)
    {
        if (bullet.TryGetComponent(out Bullet bulletItem))
        {
            if (bulletItem.GetReverseStatus() == false)
            {
                _counter.Add();
                spawner.RemoveObject(this);
            }
        }
    }
}
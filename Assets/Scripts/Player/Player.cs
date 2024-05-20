using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover), typeof(PlayerShoot), typeof(ScoreCounter))]
[RequireComponent(typeof(PlayerCollisionHandler))]
public class Player : MonoBehaviour
{
    private PlayerMover _playerMover;
    private PlayerShoot _playerShoot;
    private ScoreCounter _scoreCounter;
    private PlayerCollisionHandler _handler;

    public event Action GameOver;

    private void Awake()
    {
        _scoreCounter = GetComponent<ScoreCounter>();
        _handler = GetComponent<PlayerCollisionHandler>();
        _playerMover = GetComponent<PlayerMover>();
        _playerShoot = GetComponent<PlayerShoot>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Enemy)
        {
            GameOver?.Invoke();
        }
        else if (interactable is Bullet)
        {
            GameOver?.Invoke();
        }
        else if (interactable is Ground)
        {
            GameOver?.Invoke();
        }
    }

    public void StartPlay()
    {
        _scoreCounter.Reset();
        _playerMover.Reset();
        _playerMover.ActivateInput();
        _playerShoot.ActivateInput();
    }

    public void EndPlay()
    {
        _scoreCounter.Reset();
        _playerMover.DeactivateInput();
        _playerShoot.DeactivateInput();
    }
}
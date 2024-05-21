using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Bullet : MonoBehaviour, IInteractable
{
    [SerializeField] private bool _isEnemyAmmo;
    
    private float _speed;

    private void Update()
    {
        Move();
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public bool GetAmmoOwner()
    {
        return _isEnemyAmmo;
    }

    private void Move()
    {
        transform.position += Vector3.right * _speed * Time.deltaTime;
    }
}
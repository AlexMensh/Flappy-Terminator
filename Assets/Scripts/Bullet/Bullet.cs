using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Bullet : MonoBehaviour, IInteractable
{
    [SerializeField] private bool _isReversed;

    private float _speed;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        if (_isReversed == true)
        {
            transform.Rotate(0f, 180f, 0f);
            _spriteRenderer.material.color = Color.red;
            _speed = -_speed;
        }
    }

    private void Update()
    {
        Move();
    }

    public void ReverseMovement()
    {
        _isReversed = true;
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public bool GetReverseStatus()
    {
        return _isReversed;
    }

    private void Move()
    {
        transform.position += Vector3.right * _speed * Time.deltaTime;
    }
}
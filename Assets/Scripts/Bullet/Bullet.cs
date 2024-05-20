using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class Bullet : MonoBehaviour, IInteractable
{
    [SerializeField] private bool _isReversed;

    private float _speed;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move(_isReversed);
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

    private void Move(bool isPlayer)
    {
        if (_isReversed == false)
        {
            _rigidbody2D.velocity = Vector2.right * _speed;
        }
        else if (_isReversed == true)
        {
            _rigidbody2D.velocity = Vector2.left * _speed;
            _spriteRenderer.flipX = true;
            _spriteRenderer.material.color = Color.red;
        }
    }
}
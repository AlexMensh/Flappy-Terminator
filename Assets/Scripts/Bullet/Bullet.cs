using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _isReversed;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
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

    private void Move(bool isPlayer)
    {
        if (_isReversed == false)
        {
            _rigidbody2D.velocity = Vector2.right * _speed;
        }
        else if (_isReversed == true)
        {
            _rigidbody2D.velocity = Vector2.left * _speed;
        }

    }

}

using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool isActive;

    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        if (isActive)
        {
            Move();
        }
    }

    public void Reset()
    {
        isActive = true;
        transform.position = _startPosition;
    }

    private void Move()
    {
        Vector3 mousePosition = Input.mousePosition;

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = new Vector2(transform.position.x, worldPosition.y * _speed);
    }
}
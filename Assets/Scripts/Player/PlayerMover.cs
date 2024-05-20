using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _isActive;

    private void Update()
    {
        if (_isActive)
        {
            Move();
        }
    }

    public void ActivateInput()
    {
        _isActive = true;
    }

    public void DeactivateInput()
    {
        _isActive = false;
    }

    private void Move()
    {
        Vector3 mousePosition = Input.mousePosition;

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = new Vector2(transform.position.x, worldPosition.y * _speed);
    }
}
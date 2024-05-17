using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;

        Reset();
    }

    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = new Vector2(transform.position.x, worldPosition.y);
    }

    public void Reset()
    {
        transform.position = _startPosition;
    }
}
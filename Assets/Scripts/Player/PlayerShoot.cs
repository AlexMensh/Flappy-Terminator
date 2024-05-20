using UnityEngine;

[RequireComponent(typeof(BulletSpawner))]
public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private bool _isActive;

    private BulletSpawner _bulletSpawner;

    private void Start()
    {
        _bulletSpawner = GetComponent<BulletSpawner>();
    }

    private void Update()
    {
        if (_isActive)
        {
            Shoot();
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

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _bulletSpawner.SpawnObject(transform.position);
        }
    }
}
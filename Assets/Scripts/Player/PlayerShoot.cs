using UnityEngine;

[RequireComponent (typeof(BulletSpawner))]
public class PlayerShoot : MonoBehaviour
{
    private BulletSpawner _bulletSpawner;

    private void Start()
    {
        _bulletSpawner = GetComponent<BulletSpawner>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _bulletSpawner.SpawnObject(transform.position);
        }
    }
}

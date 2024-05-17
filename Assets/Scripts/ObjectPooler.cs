using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler<T> where T : MonoBehaviour
{
    private Transform _container;
    private T _prefab;

    private Queue<T> _pool = new Queue<T>();

    public IEnumerable<T> PooledObjects => _pool;

    public ObjectPooler(T prefab, Transform container)
    {
        _prefab = prefab;
        _container = container;
    }

    public T GetObject()
    {
        if (_pool.Count == 0)
        {
            var item = Object.Instantiate(_prefab);
            item.transform.parent = _container;

            return item;
        }

        return _pool.Dequeue();
    }

    public void PutObject(T item)
    {
        _pool.Enqueue(item);
        item.gameObject.SetActive(false);
    }

    public void Reset()
    {
        _pool.Clear();
    }
}
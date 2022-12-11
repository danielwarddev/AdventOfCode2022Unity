using UnityEngine;
using UnityEngine.Pool;

public class BasicSpawner : MonoBehaviour
{
    [SerializeField] private int _capacity;
    [SerializeField] private GameObject _prefab;
    private ObjectPool<GameObject> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, true, _capacity);
    }

    public GameObject Get()
    {
        return _pool.Get();
    }

    public void Release(GameObject go)
    {
        _pool.Release(go);
    }

    private GameObject CreatePooledItem()
    {
        var go = Instantiate(_prefab);
        go.transform.SetParent(transform);
        go.SetActive(false);
        return go;
    }

    private void OnTakeFromPool(GameObject go)
    {
        go.SetActive(true);
    }

    private void OnReturnedToPool(GameObject go)
    {
        go.SetActive(false);
    }

    private void OnDestroyPoolObject(GameObject go)
    {
        Destroy(go);
    }
}
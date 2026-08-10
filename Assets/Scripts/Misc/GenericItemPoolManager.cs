using UnityEngine;

public class GenericItemPoolManager<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T itemPrefab;
    [SerializeField] protected int itemCount;
    [SerializeField] protected Transform container;
    protected ObjectPool<T> _itemPool;
    public ObjectPool<T> ItemPool => _itemPool;

    protected virtual void Awake()
    {
        _itemPool = new ObjectPool<T>(itemPrefab, itemCount, container);
        _itemPool.AutoExpand = true;
    }

    public T GetItem()
    {
        return _itemPool.GetFreeElement();
    }

    public void ReturnItem(T item)
    {
        _itemPool.Release(item);
    }
}
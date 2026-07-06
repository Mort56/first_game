using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    public T Prefab { get; }
    public bool AutoExpand { get; set; }
    public Transform Container { get; }

    private List<T> _pool;

    public int CountActive => _pool.Count(x => x.gameObject.activeSelf);
    public int CountInactive => _pool.Count(x => !x.gameObject.activeSelf);


    public ObjectPool(T prefab, int count, Transform container = null)
    {
        this.Prefab = prefab;
        this.Container = container;

        CreatePool(count);
    }

    private void CreatePool(int count)
    {
        _pool = new List<T>();
        for (int i = 0; i < count; i++)
            CreateObject();
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        var createObject = Object.Instantiate(Prefab, Container);
        createObject.gameObject.SetActive(isActiveByDefault);
        _pool.Add(createObject);
        return createObject;
    }

    public bool TryGetFreeElement(out T element)
    {
        foreach (var obj in _pool)
            if (!obj.gameObject.activeSelf)
            {
                element = obj;
                return true;
            }

        element = null;
        return false;
    }

    public T GetFreeElement()
    {
        if (TryGetFreeElement(out var element))
        {
            element.gameObject.SetActive(true);
            return element;
        }

        if (AutoExpand)
            return CreateObject(true);

        return null;
    }

    public void Release(T element)
    {
        element.gameObject.SetActive(false);
    }

    public void ReleaseAll()
    {
        foreach (var obj in _pool)
            obj.gameObject.SetActive(false);
    }

    public void Expand(int count)
    {
        for (var i = 0; i < count; i++)
            CreateObject(true);
    }
}

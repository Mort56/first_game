using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

public class GenericDatabase<T> : Database where T : new()
{

    [SerializeField] protected List<T> items;
    [SerializeField] private T currentItem;
    [SerializeField] private int _currentId;


    public override void Create()
    {
        if (items == null)
            items = new List<T>();

        T item = new T();
        items.Add(item);
        _currentId = items.Count - 1;
        currentItem = items[_currentId];
    }

    public override void Delete()
    {
        if (items == null || currentItem == null)
            return;

        items.Remove(currentItem);
        _currentId = 0;

        if (items.Count == 0)
            Create();
        else
            currentItem = items[_currentId];
    }

    public override void Next()
    {
        if (_currentId + 1 < items.Count)
        {
            _currentId += 1;
            currentItem = items[_currentId];
        }
    }

    public override void Prev()
    {
        if (_currentId - 1 >= 0)
        {
            _currentId -= 1;
            currentItem = items[_currentId];
        }
    }
}

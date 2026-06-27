using UnityEngine;
using System.Collections.Generic;

public class GenericDatabase<T> : Database where T : new()
{
    
    [SerializeField] private List<T> Items;
    [SerializeField] private T currentItem;
    private int _currentId;

    public override void Create()
    {
        if (Items == null)
            Items = new List<T>();

        T item = new T();
        Items.Add(item);
        _currentId = Items.Count - 1;
        currentItem = Items[_currentId];
    }

    public override void Delete()
    {
        if (Items == null || currentItem == null)
            return;

        Items.Remove(currentItem);
        _currentId = 0;

        if (Items.Count == 0)
            Create();
        else
            currentItem = Items[_currentId];
    }

    public override void Next()
    {
        if (_currentId + 1 < Items.Count)
        {
            _currentId += 1;
            currentItem = Items[_currentId];
        }
    }

    public override void Prev()
    {
        if (_currentId - 1 >= 0)
        {
            _currentId -= 1;
            currentItem = Items[_currentId];
        }
    }
}

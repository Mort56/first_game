using UnityEngine;
using System.Collections.Generic;

public class GenericDatabase<T> : Database where T : new()
{

    [SerializeField] protected List<T> items;
    [SerializeField] private T currentItem;
    [SerializeField] private int currentId;


    public override void Create()
    {
        if (items == null)
            items = new List<T>();

        T item = new T();
        items.Add(item);
        currentId = items.Count - 1;
        currentItem = items[currentId];
    }

    public override void Delete()
    {
        if (items == null || currentItem == null)
            return;

        items.Remove(currentItem);
        currentId = 0;

        if (items.Count == 0)
            Create();
        else
            currentItem = items[currentId];
    }

    public override void Next()
    {
        if (currentId + 1 < items.Count)
        {
            currentId += 1;
            currentItem = items[currentId];
        }
    }

    public override void Prev()
    {
        if (currentId - 1 >= 0)
        {
            currentId -= 1;
            currentItem = items[currentId];
        }
    }
}

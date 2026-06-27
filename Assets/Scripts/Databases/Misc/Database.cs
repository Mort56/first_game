using UnityEngine;

public abstract class Database : ScriptableObject
{
    public abstract void Create();
    public abstract void Delete();
    public abstract void Next();
    public abstract void Prev();
}

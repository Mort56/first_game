using UnityEngine;

public class SpearSpawner : GenericItemPoolManager<Spear>
{
    public static SpearSpawner Instance;

    protected override void Awake()
    {
        Instance = this;
        base.Awake();
    }
}
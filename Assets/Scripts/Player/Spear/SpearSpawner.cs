using UnityEngine;

public class SpearSpawner : GenericItemPoolManager<SpearFindTargetsEnemy>
{
    public static SpearSpawner Instance;

    protected override void Awake()
    {
        Instance = this;
        base.Awake();
    }
}
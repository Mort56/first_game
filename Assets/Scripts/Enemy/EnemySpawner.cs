using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyController prefab;
    private ObjectPool<EnemyController> _enemyPool;
    public ObjectPool<EnemyController> EnemyPool => _enemyPool;


    private void Awake()
    {
        _enemyPool = new ObjectPool<EnemyController>(prefab, 5, transform);
    }
}

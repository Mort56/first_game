using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyController prefab;
    [SerializeField] private int enemyCount = 5;
    private ObjectPool<EnemyController> _enemyPool;
    public ObjectPool<EnemyController> EnemyPool => _enemyPool;


    private void Awake()
    {
        _enemyPool = new ObjectPool<EnemyController>(prefab, enemyCount, transform);
    }
}

using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyController prefab;
    [SerializeField] private float maxMapXSize;
    [SerializeField] private float maxMapYSize;
    private ObjectPool<EnemyController> _enemyPool;


    private void Awake()
    {
        _enemyPool = new ObjectPool<EnemyController>(prefab, 5, transform);
    }

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            var enemy = _enemyPool.GetFreeElement();
            enemy.transform.position = GetRandomSoawnPosition(maxMapXSize, maxMapYSize);
            Debug.Log(enemy.transform.position);
        }
    }

    private Vector3 GetRandomSoawnPosition(float maxXCoordinats, float maxYCoordinats)
    {
        maxXCoordinats -= 5f;
        var x = Random.Range(-1 * maxXCoordinats, maxXCoordinats); ;
        maxYCoordinats -= 5f;
        var y = Random.Range(-1 * maxYCoordinats, maxYCoordinats);
        return new Vector3(x, y, 0);
    }
}

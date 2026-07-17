using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyController prefab;
    [SerializeField] private GameObject gameBoard;
    private float _maxMapXSize;
    private float _maxMapYSize;
    private ObjectPool<EnemyController> _enemyPool;
    public ObjectPool<EnemyController> EnemyPool => _enemyPool;


    private void Awake()
    {
        _enemyPool = new ObjectPool<EnemyController>(prefab, 5, transform);
        _maxMapXSize = gameBoard.transform.localScale.x;
        _maxMapYSize = gameBoard.transform.localScale.y;
    }

    private void Start()
    {
        /*
        for (int i = 0; i < 5; i++)
        {
            var enemy = _enemyPool.GetFreeElement();
            enemy.transform.position = GetRandomSpawnPosition();
        }
        */
    }

    public Vector3 GetRandomSpawnPosition()
    {
        _maxMapXSize -= 5f;
        var x = Random.Range(-1 * _maxMapXSize, _maxMapYSize); ;
        _maxMapYSize -= 5f;
        var y = Random.Range(-1 * _maxMapXSize, _maxMapYSize);
        return new Vector3(x, y, 0);
    }
}

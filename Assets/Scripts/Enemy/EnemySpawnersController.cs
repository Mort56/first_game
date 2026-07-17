using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnersController : MonoBehaviour
{
    [SerializeField] private List<EnemySpawner> enemySpawnersController;
    [SerializeField] private int minEnemySpawn;
    [SerializeField] private int maxEnemySpawn;
    [SerializeField] private float spawnTime;
    [SerializeField] private GameObject gameBoard;

    private EnemyController _currentEnemy;
    private bool _isEnemySpawn = false;
    private float _maxMapXSize;
    private float _maxMapYSize;

    private void Awake()
    {
        _maxMapXSize = gameBoard.transform.localScale.x;
        _maxMapYSize = gameBoard.transform.localScale.y;
    }

    private void FixedUpdate()
    {
        if (!_isEnemySpawn)
            StartCoroutine(GetRandomEnemyCoroutine(minEnemySpawn, maxEnemySpawn, spawnTime));
    }

    private void GetRandomEnemy()
    {
        var number = Random.Range(1, 100);
        switch (number)
        {
            case <= 20:
                _currentEnemy = enemySpawnersController[0].EnemyPool.GetFreeElement();
                break;
            case <= 35:
                _currentEnemy = enemySpawnersController[1].EnemyPool.GetFreeElement();
                break;
            case <= 55:
                _currentEnemy = enemySpawnersController[2].EnemyPool.GetFreeElement();
                break;
            case <= 70:
                _currentEnemy = enemySpawnersController[3].EnemyPool.GetFreeElement();
                break;
            default:
                _currentEnemy = null;
                break;
        }

        if (_currentEnemy != null)
            _currentEnemy.transform.position = GetRandomSpawnPosition();
    }

    private IEnumerator GetRandomEnemyCoroutine(int minEnemyCount, int maxEnemyCount, float spawnTime)
    {
        var count = Random.Range(minEnemyCount, maxEnemyCount);
        _isEnemySpawn = true;
        while (count != 0)
        {
            GetRandomEnemy();
            count -= 1;
        }
        yield return new WaitForSeconds(spawnTime);
        _isEnemySpawn = false;
    }

    private Vector3 GetRandomSpawnPosition()
    {
        var boundsX = _maxMapXSize - 5f;
        var boundsY = _maxMapYSize - 5f;
        var x = Random.Range(-boundsX, boundsX);
        var y = Random.Range(-boundsY, boundsY);
        return new Vector3(x, y, 0);
    }
}
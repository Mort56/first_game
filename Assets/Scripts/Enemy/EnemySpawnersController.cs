using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnersController : MonoBehaviour
{
    [SerializeField] private List<EnemySpawner> enemySpawnersController;
    [SerializeField] private SpriteRenderer mapSpriteRenderer;
    [SerializeField] private int minEnemySpawn;
    [SerializeField] private int maxEnemySpawn;
    [SerializeField] private float spawnDuration;

    private WaitForSeconds _waitSpawnDuration;
    private EnemyController _currentEnemy;
    private bool _isEnemySpawned = false;
    private float _maxMapXSize;
    private float _maxMapYSize;

    private void Awake()
    {
        _waitSpawnDuration = new WaitForSeconds(spawnDuration);
        _maxMapXSize = mapSpriteRenderer.bounds.size.x;
        _maxMapYSize = mapSpriteRenderer.bounds.size.y;
    }

    private void FixedUpdate()
    {
        if (!_isEnemySpawned)
            StartCoroutine(GetRandomEnemyCoroutine(minEnemySpawn, maxEnemySpawn, spawnDuration));
    }

    private void GetRandomEnemy()
    {
        var number = Random.Range(1, 100);
        switch (number)
        {
            case <= 20:
                _currentEnemy = enemySpawnersController[0].ItemPool.GetFreeElement();
                break;
            case <= 40:
                _currentEnemy = enemySpawnersController[1].ItemPool.GetFreeElement();
                break;
            case <= 60:
                _currentEnemy = enemySpawnersController[2].ItemPool.GetFreeElement();
                break;
            case <= 75:
                _currentEnemy = enemySpawnersController[3].ItemPool.GetFreeElement();
                break;
            case <= 95:
                _currentEnemy = enemySpawnersController[4].ItemPool.GetFreeElement();
                break;
            case <= 100:
                _currentEnemy = enemySpawnersController[5].ItemPool.GetFreeElement();
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
        _isEnemySpawned = true;
        while (count > 0)
        {
            GetRandomEnemy();
            count -= 1;
        }
        yield return _waitSpawnDuration;
        _isEnemySpawned = false;
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
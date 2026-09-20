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

    private List<float> _enemySpawnChances;
    private WaitForSeconds _waitSpawnDuration;
    private EnemyController _currentEnemy;
    private bool _isEnemySpawned = false;
    private float _maxMapXSize;
    private float _maxMapYSize;

    private void Awake()
    {
        _enemySpawnChances = new List<float>();
        _waitSpawnDuration = new WaitForSeconds(spawnDuration);
        _maxMapXSize = mapSpriteRenderer.bounds.size.x;
        _maxMapYSize = mapSpriteRenderer.bounds.size.y;
    }

    private void Start()
    {
        SetEnemySpawnChances();
    }

    private void FixedUpdate()
    {
        if (!_isEnemySpawned)
            StartCoroutine(GetRandomEnemyCoroutine(minEnemySpawn, maxEnemySpawn, spawnDuration));
    }

    private void SetEnemySpawnChances()
    {
        for (var i = 0; i < enemySpawnersController.Count; i++)
        {
            _currentEnemy = enemySpawnersController[i].GetItem();
            _enemySpawnChances.Add(_currentEnemy.Data.SpawnChance);
            enemySpawnersController[i].ReturnItem(_currentEnemy);
        }
    }

    private void GetRandomEnemy()
    {
        var spawnChanceForCurrentEnemy = Random.Range(0, 101);
        float spawnChances = 0f;
        for (var i = 0; i < enemySpawnersController.Count; i++)
        {
            spawnChances += _enemySpawnChances[i];
            if (spawnChances >= spawnChanceForCurrentEnemy)
            {
                _currentEnemy = enemySpawnersController[i].GetItem();
                break;
            }
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
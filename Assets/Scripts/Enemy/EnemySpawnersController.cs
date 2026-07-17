using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawnersController : MonoBehaviour
{
    [SerializeField] private List<EnemySpawner> enemySpawnersController;
    [SerializeField] private int minEnemySpawn;
    [SerializeField] private int maxEnemySpawn;
    [SerializeField] private float spawnTime;
    private bool _isEnemySpawn = false;

    private void FixedUpdate()
    {
        if (!_isEnemySpawn)
            StartCoroutine(GetRandomEnemyCoroutine(minEnemySpawn, maxEnemySpawn, spawnTime));
    }
    
    private void GetRandomEnemy()
    {
        var number = Random.Range(1, 100f);
        switch (number)
        {
            case <= 20:
                enemySpawnersController[0].EnemyPool.GetFreeElement();
                break;
            case <= 35:
                enemySpawnersController[1].EnemyPool.GetFreeElement();
                break;
            case <= 55:
                enemySpawnersController[2].EnemyPool.GetFreeElement();
                break;
            case <= 70:
                enemySpawnersController[3].EnemyPool.GetFreeElement();
                break;
            default:
                break;
                /*
            case <= 25:
                enemySpawnersController[4].EnemyPool.GetFreeElement();
                break;
            case <= 25:
                enemySpawnersController[5].EnemyPool.GetFreeElement();
                break;
                */
        }
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
    
}

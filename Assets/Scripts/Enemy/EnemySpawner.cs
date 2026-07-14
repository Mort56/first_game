using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyController prefab;
    [SerializeField] private GameObject gameBoard;
    private float _maxMapXSize;
    private float _maxMapYSize;
    private ObjectPool<EnemyController> _enemyPool;


    private void Awake()
    {
        _enemyPool = new ObjectPool<EnemyController>(prefab, 5, transform);
        _maxMapXSize = gameBoard.transform.localScale.x;
        _maxMapYSize = gameBoard.transform.localScale.y;
    }

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            var enemy = _enemyPool.GetFreeElement();
            enemy.transform.position = GetRandomSoawnPosition(_maxMapXSize, _maxMapYSize);
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

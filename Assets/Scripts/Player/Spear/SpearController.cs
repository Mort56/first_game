using System;
using System.Collections;
using UnityEngine;

public class SpearController : MonoBehaviour
{
    [SerializeField] private SpearFindTargetsEnemy spearFindTargetsEnemy;
    public event EventHandler onAttack;

    private WaitForSeconds _waitSpearSpawn;
    private float _spearSpawnTime = 0.5f;
    private bool _isAttack = false;
    private float _speed = 10f;
    private Vector2 _direction;
    private Vector2 _targetDirection;
    public Vector2 TargetDirection => _targetDirection;

    private void Awake()
    {
        _waitSpearSpawn = new WaitForSeconds(_spearSpawnTime);
        _isAttack = false;
    }

    private void TargetDirectionSearchResult(int spearNumber)
    {
        _targetDirection = spearFindTargetsEnemy.Objects[spearNumber].transform.position;
        onAttack?.Invoke(this, EventArgs.Empty);
    }

    private void FixedUpdate()
    {
        if (!_isAttack)
            StartCoroutine(SpawnSpearCoroutine());
    }

    private IEnumerator SpearAttackCoroutine(int spearNumber)
    {
        var spear = SpearSpawner.Instance.GetItem();
        spear.transform.position = Player.Instance.transform.position;
        var attackTime = 5f;
        TargetDirectionSearchResult(spearNumber);
        _direction = spear.GetComponent<SpearMovement>().Direction;
        Debug.Log($"копье взято, направление на врага - {_direction}");
        while (attackTime > 0f)
        {
            attackTime -= Time.deltaTime;
            spear.transform.position += (Vector3)(_direction * _speed * Time.fixedDeltaTime);
            yield return null;
        }
    }

    private IEnumerator SpawnSpearCoroutine()
    {
        _isAttack = true;
        var maxSpearCount = spearFindTargetsEnemy.NumberOfTargetsFound;
        var number = 0;
        while (maxSpearCount > number)
        {
            Debug.Log("берем копье из пула");
            StartCoroutine(SpearAttackCoroutine(number));
            yield return _waitSpearSpawn;
            number++;
        }
        _isAttack = false;
    }
}

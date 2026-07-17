using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private static readonly int IsAttackedHash = Animator.StringToHash("isAttacked");
    [SerializeField] private NavMeshAgent navMesh;
    [SerializeField] EnemyController enemyController;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;

    private const float AttackRangeTolerance = 0.15f;
    private EnemyState _state;
    private float _speed;
    private float _minimumXDistanceForAttack;
    private float _minimumYDistanceForAttack;
    private float _cooldawn;
    private bool _attackReset = false;
    private bool _isAttacking = false;

    private void Start()
    {
        navMesh.updateRotation = false;
        navMesh.updateUpAxis = false;
        _state = EnemyState.chase;
        _speed = enemyController.Data.Speed;
        _minimumXDistanceForAttack = enemyController.Data.AttackDistanceByX;
        _minimumYDistanceForAttack = enemyController.Data.AttackDistanceByY;
        _cooldawn = enemyController.Data.Cooldawn;
        navMesh.speed = _speed;
    }

    private void FixedUpdate()
    {
        if (IsCanAttack())
            _state = EnemyState.attack;
        else
            _state = EnemyState.chase;

        Movement();
        UpdateVisualFacing();
    }

    private void UpdateVisualFacing()
    {
        if (navMesh.velocity.x > 0.1f)
            transform.rotation = Quaternion.identity;
        else if (navMesh.velocity.x < -0.1f)
            transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    private void Movement()
    {
        switch (_state)
        {
            case EnemyState.chase:
                navMesh.SetDestination(GetPositionForChase());
                break;
            case EnemyState.attack:
                if (!_isAttacking)
                    StartCoroutine(AttackCoroutine());
                break;
        }
    }

    private bool IsCanAttack()
    {
        float deltaX = Mathf.Abs(Player.Instance.transform.position.x - transform.position.x);
        float deltaY = Mathf.Abs(Player.Instance.transform.position.y - transform.position.y);

        bool xInRange = deltaX < Mathf.Abs(_minimumXDistanceForAttack) + AttackRangeTolerance;
        bool yInRange = deltaY < Mathf.Abs(_minimumYDistanceForAttack) + AttackRangeTolerance;

        return xInRange && yInRange;
    }

    private IEnumerator AttackCoroutine()
    {
        var attackTime = _cooldawn;
        _isAttacking = true;
        animator.SetBool(IsAttackedHash, IsCanAttack());
        while (attackTime > 0f)
        {
            navMesh.isStopped = true;
            navMesh.velocity = Vector3.zero;
            navMesh.ResetPath();
            attackTime -= Time.deltaTime;
            yield return null;
        }
        animator.SetBool(IsAttackedHash, _attackReset);
        _isAttacking = false;
        navMesh.isStopped = false;
    }

    private Vector3 GetPositionForChase()
    {
        Vector3 position = Player.Instance.transform.position;
        bool playerIsToTheRight = Player.Instance.transform.position.x > transform.position.x;

        if (playerIsToTheRight)
            position.x -= enemyController.Data.AttackDistanceByX;
        else
            position.x += enemyController.Data.AttackDistanceByX;

        position.y += enemyController.Data.AttackDistanceByY;

        const float attackRangeSafetyMargin = 0.9f;
        Vector3 offsetFromPlayer = position - Player.Instance.transform.position;
        position = Player.Instance.transform.position + offsetFromPlayer * attackRangeSafetyMargin;

        return position;
    }
}

public enum EnemyState
{
    attack,
    chase
}
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private static readonly int IS_ATTACKED = Animator.StringToHash("isAttacked");
    [SerializeField] private NavMeshAgent navMesh;
    [SerializeField] EnemyController enemyController;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    private EnemyState _state;
    private float _speed;
    private float _damage;
    private float _minimumXDistanceForAttack;
    private float _minimumYDistanceForAttack;
    private float _cooldawn;
    private bool _attackReset = false;

    private void Awake()
    {
        navMesh.updateRotation = false;
        navMesh.updateUpAxis = false;
        _state = EnemyState.chase;
        _speed = enemyController.Data.Speed;
        _damage = enemyController.Data.Damage;
        _minimumXDistanceForAttack = enemyController.Data.AttackDistanceByX;
        _minimumYDistanceForAttack = enemyController.Data.AttackDistanceByY;
        _cooldawn = enemyController.Data.Cooldawn;
    }

    private void FixedUpdate()
    {
        if (IsCanAttack())
            _state = EnemyState.attack;
        else
            _state = EnemyState.chase;
        Movement();
            
    }

    private void Movement()
    {
        switch (_state)
        {
            case EnemyState.chase:
                navMesh.SetDestination(Player.Instance.transform.position);
                break;
            case EnemyState.attack:
                StartCoroutine(AttackCoroutine());
                break;
        }
    }

    private bool IsCanAttack()
    {
        if ((Mathf.Abs(Player.Instance.transform.position.x - this.transform.position.x) < _minimumXDistanceForAttack) && 
            (Mathf.Abs(Player.Instance.transform.position.y - this.transform.position.y)) < _minimumYDistanceForAttack)
            return true;
        else
            return false;
    }

    private IEnumerator AttackCoroutine()
    {
        var attackTime = _cooldawn;
        animator.SetBool(IS_ATTACKED, IsCanAttack());
        while (attackTime > 0f)
        {
            navMesh.isStopped = true;
            navMesh.velocity = Vector3.zero;
            navMesh.ResetPath();
            attackTime -= Time.deltaTime;
            yield return null;
        }
        animator.SetBool(IS_ATTACKED, _attackReset);
    }
}

public enum EnemyState
{
    attack, 
    chase
}
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private PolygonCollider2D enemyAttackCollider;
    [SerializeField] private BoxCollider2D enemyCollider;
    [SerializeField] private EnemyController enemyController;
    private PolygonCollider2D _defaultEnemyAttackColliderPosition;

    private float _damage;

    private void Awake()
    {
        _defaultEnemyAttackColliderPosition = enemyAttackCollider;
    }

    private void Start()
    {
        enemyAttackCollider.enabled = false;
        enemyCollider.enabled = true;
        _damage = enemyController.Data.Damage;
    }

    public void EnableAttackCollider()
    {
        enemyAttackCollider.enabled = true;
    }

    public void DisableAttackCollider()
    {
        enemyAttackCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            Player.Instance.PlayerHealth.TakeDamage(_damage);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            Player.Instance.PlayerHealth.TakeDamage(_damage / 2);
    }

    public void MoveEnemyAttackColliderToRight()
    {
        enemyAttackCollider.transform.localPosition += Vector3.right * 0.25f;
    }

    public void ResetEnemyAttackCollider()
    {
        enemyAttackCollider = _defaultEnemyAttackColliderPosition;
    }
}

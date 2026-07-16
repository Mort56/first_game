using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private PolygonCollider2D enemyAttackCollider;
    [SerializeField] private BoxCollider2D enemyCollider;
    [SerializeField] private EnemyController enemyController;
    private Vector2 _defaultPolygonOffset;

    private float _damage;

    private void Start()
    {
        _defaultPolygonOffset = enemyAttackCollider.offset;
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
        ResetEnemyAttackCollider();
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
        enemyAttackCollider.offset += Vector2.right * 0.25f;
    }

    public void ResetEnemyAttackCollider()
    {
        enemyAttackCollider.offset = _defaultPolygonOffset;
    }
}

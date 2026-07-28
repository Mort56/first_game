using UnityEngine;

public class EnemyAttack : AbstractEnemyAttack
{
    [SerializeField] private float attackColliderFlipOffsetX = 0.25f;
    [SerializeField] private Collider2D enemyAttackCollider;
    private Vector2 _defaultPolygonOffset;
    protected float _contactDamage;


    protected override void Start()
    {
        base.Start();
        _defaultPolygonOffset = enemyAttackCollider.offset;
        enemyAttackCollider.enabled = false;
        _contactDamage = damage / 2f;
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

    public void MoveEnemyAttackColliderToRight()
    {
        enemyAttackCollider.offset += Vector2.right * attackColliderFlipOffsetX;
    }

    public void ResetEnemyAttackCollider()
    {
        enemyAttackCollider.offset = _defaultPolygonOffset;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            Player.Instance.PlayerHealth.TakeDamage(_contactDamage);
    }
}

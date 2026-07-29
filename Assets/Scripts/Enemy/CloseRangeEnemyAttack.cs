using UnityEngine;

public class CloseRangeEnemyAttack : AbstractEnemyAttack
{
    [SerializeField] private float attackColliderFlipOffsetX = 0.25f;
    [SerializeField] private Collider2D enemyAttackCollider;
    private Vector2 _defaultPolygonOffset;


    protected override void Start()
    {
        base.Start();
        _defaultPolygonOffset = enemyAttackCollider.offset;
        enemyAttackCollider.enabled = false;
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
}

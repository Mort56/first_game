using UnityEngine;

public class BulletMovement : ProjectileMovement
{
    private static readonly int DestroyBulletHash = Animator.StringToHash("destroyBullet");
    [SerializeField] private Animator animator;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.CompareTag("Player"))
        {
            _direction = Vector2.zero;
            Player.Instance.PlayerHealth.TakeDamage(_damage);
            _isNeedDestroy = true;
        }
        if (_isNeedDestroy)
            animator.SetTrigger(DestroyBulletHash);
    }

    public void ReturnBulletToPool()
    {
        BulletSpawner.Instance.ReturnItem(this);
    }
}

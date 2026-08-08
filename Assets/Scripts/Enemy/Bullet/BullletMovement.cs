using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    protected static readonly int DestroyBulletHash = Animator.StringToHash("destroyBullet");
    [SerializeField] protected Animator animator;
    [SerializeField] protected float speed = 10f;
    protected Vector2 _direction;

    public virtual void GetTargetVector(Vector2 targetPosition)
    {
        _direction = (targetPosition - (Vector2)transform.position).normalized;
    }

    protected virtual void FixedUpdate()
    {
        transform.position += (Vector3)(_direction * speed * Time.fixedDeltaTime);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Wall") || collision.CompareTag("Weapon"))
        {
            _direction = Vector2.zero;
            animator.SetTrigger(DestroyBulletHash);
        }
    }

    public virtual void ReturnBulletToPool()
    {
        BulletSpawner.Instance.ReturnItem(this);
    }
}

using UnityEngine;

public abstract class ProjectileMovement : MonoBehaviour
{

    [SerializeField] protected float speed = 10f;
    protected bool _isNeedDestroy = false;
    protected float _damage;
    protected Vector2 _direction;

    public virtual void GetTargetVector(Vector2 targetPosition, float damage)
    {
        _damage = damage;
        _direction = (targetPosition - (Vector2)transform.position).normalized;
    }

    protected virtual void FixedUpdate()
    {
        transform.position += (Vector3)(_direction * speed * Time.fixedDeltaTime);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall") || collision.CompareTag("Weapon"))
        {
            _direction = Vector2.zero;
            _isNeedDestroy = true;
        }
        else
            _isNeedDestroy = false;
    }
}
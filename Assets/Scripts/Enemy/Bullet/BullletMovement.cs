using TMPro;
using UnityEngine;

public class BulletMovement : AbstractEnemyAttack
{
    [SerializeField] private float speed = 0.25f;
    private float _damage;
    private Vector2 _direction;

    protected override void Start()
    {
        base.Start();
    }

    public void GetTargetVector(Vector2 targetPosition, float damage)
    {
        _damage = damage;
        _direction = (targetPosition - (Vector2)transform.position).normalized;
    }

    private void FixedUpdate()
    {
        transform.position += (Vector3)(_direction * speed * Time.fixedDeltaTime);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.CompareTag("Player") || collision.CompareTag("Wall"))
            BulletSpawner.Instance.ReturnBullet(this);
    }
}

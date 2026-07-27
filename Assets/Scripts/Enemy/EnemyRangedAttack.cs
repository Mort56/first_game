using UnityEngine;

public class EnemyRangedAttack : MonoBehaviour
{
    [SerializeField] EnemyController enemyController;
    [SerializeField] private float speed = 0.25f;
    private Vector2 _direction;
    private float _damage;

    private void Start()
    {
        GetTargetVector();
        _damage = enemyController.Data.Damage;
    }

    private void GetTargetVector()
    {
        _direction = ((Vector2)Player.Instance.transform.position - (Vector2)transform.position).normalized;
    }

    private void FixedUpdate()
    {
        transform.position += (Vector3)(_direction * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            Player.Instance.PlayerHealth.TakeDamage(_damage);
    }
}

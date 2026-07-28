using UnityEngine;

public abstract class AbstractEnemyAttack : MonoBehaviour
{
    [SerializeField] protected EnemyController enemyController;
    protected float damage;

    protected virtual void Start()
    {
        damage = enemyController.Data.Damage;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            Player.Instance.PlayerHealth.TakeDamage(damage);
    }
}

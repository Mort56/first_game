using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public abstract class AbstractEnemyAttack : MonoBehaviour
{
    [SerializeField] protected EnemyController enemyController;
    protected float damage;
    protected float contactDamage;

    protected virtual void Start()
    {
        if (enemyController != null)
        {
            damage = enemyController.Data.Damage;
            contactDamage = damage / 2f;
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            Player.Instance.PlayerHealth.TakeDamage(damage);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            Player.Instance.PlayerHealth.TakeDamage(contactDamage);
    }
}

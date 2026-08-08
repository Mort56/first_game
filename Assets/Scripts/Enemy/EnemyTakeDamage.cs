using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    [SerializeField] private Health health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
            health.TakeDamage(Player.Instance.Damage);
    }
}

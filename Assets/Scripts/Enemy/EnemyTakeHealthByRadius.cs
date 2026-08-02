using UnityEngine;

public class EnemyTakeHealthByRadius : GenericFindByRadius<EnemyController>
{
    [SerializeField] private int enemysToHealthCount;

    public override void GetDamageToObjects()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, radius, damageableLayer);

        foreach (var obj in objects)
        {
            Health objectHealth = obj.GetComponent<Health>();
            if (objectHealth != null && enemysToHealthCount != 0)
            {
                objectHealth.TakeHealth(damageableLayer);
                enemysToHealthCount -= 1;
            }
            else
                break;
        }
    }
}

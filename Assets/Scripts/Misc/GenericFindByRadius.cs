using UnityEngine;

public class GenericFindByRadius<T> : MonoBehaviour where T : new()
{
    [SerializeField] protected float radius;
    [SerializeField] protected float hpChangeValue;
    [SerializeField] protected LayerMask damageableLayer;

    public virtual void GetDamageToObjects()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, radius, damageableLayer);

        foreach (var obj in objects)
        {
            Health objectHealth = obj.GetComponent<Health>();
            if (objectHealth != null)
                objectHealth.TakeDamage(damageableLayer);
        }
    }
}

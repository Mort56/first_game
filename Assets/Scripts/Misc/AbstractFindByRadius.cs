using UnityEngine;

public abstract class AbstractFindByRadius : MonoBehaviour
{
    [SerializeField] protected float radius;
    [SerializeField] protected float hpChangeValue;
    [SerializeField] protected LayerMask targetLayer;

    public virtual void EffectToTargetInRadius()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);

        foreach (var obj in objects)
        {
            Health objectHealth = obj.GetComponent<Health>();
            if (objectHealth != null)
                objectHealth.TakeDamage(hpChangeValue);
        }
    }
}

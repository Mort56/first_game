using UnityEngine;

public abstract class AbstractFindByRadius : MonoBehaviour
{
    [SerializeField] protected float radius;
    [SerializeField] protected float hpChangeValue;
    [SerializeField] protected LayerMask targetLayer;
    [SerializeField] protected int targetsNumber;
    protected int numberOfTargetsFound;
    protected Collider2D[] objects;

    protected virtual void Awake()
    {
        objects = new Collider2D[targetsNumber];
    }

    protected virtual void EffectToTargetInRadius()
    {
        numberOfTargetsFound = Physics2D.OverlapCircleNonAlloc(transform.position, radius, objects, targetLayer);
    }
}

using UnityEngine;

public class EnemyHealAllies : AbstractFindByRadius
{
    [SerializeField] private int maxHealTargetPerCast;

    public override void EffectToTargetInRadius()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);
        var healTargetPerCast = maxHealTargetPerCast;

        foreach (var obj in objects)
        {
            Health objectHealth = obj.GetComponent<Health>();
            if (objectHealth != null && healTargetPerCast != 0)
            {
                objectHealth.TakeHealth(hpChangeValue);
                healTargetPerCast -= 1;
            }
            else
                break;
        }
    }
}

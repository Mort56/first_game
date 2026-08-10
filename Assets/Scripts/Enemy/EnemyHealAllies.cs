using UnityEngine;

public class EnemyHealAllies : AbstractFindByRadius
{
    public void ChangeTargetHealth()
    {
        base.EffectToTargetInRadius();
        for (var i = 0; i <  numberOfTargetsFound; i++)
        {
            objects[i].GetComponent<Health>().TakeHealth(hpChangeValue);
        }
    }
}

public class EnemyHealAllies : AbstractFindByRadius
{
    public void ChangeTargetHealth()
    {
        base.EffectToTargetInRadius();
        for (var i = 0; i <  numberOfTargetsFound; i++)
        {
            if (objects[i].TryGetComponent<Health>(out var enemy))
                enemy.TakeHealth(hpChangeValue);
        }
    }
}

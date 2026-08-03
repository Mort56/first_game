using UnityEngine;

public class Spear : AbstractFindByRadius
{
    [SerializeField] private Collider2D attackCollider;

    public override void EffectToTargetInRadius()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);

        foreach (var obj in objects)
        {
            Vector2 targetDirection = obj.transform.position;
            Launch(targetDirection);
        }
    }

    private void Launch(Vector2 direction)
    {

    }
}

using System.Collections;
using UnityEngine;

public class Spear : AbstractFindByRadius
{
    [SerializeField] private Collider2D attackCollider;
    protected Vector2 _direction;
    protected float _speed = 10f;
    private bool _isAttack = false;


    public override void EffectToTargetInRadius()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);

        foreach (var obj in objects)
        {
            Vector2 targetDirection = obj.transform.position;
            GetTargetVector(targetDirection);
            break;
        }
    }

    protected void GetTargetVector(Vector2 targetPosition)
    {
        _direction = (targetPosition - (Vector2)Player.Instance.transform.position).normalized;
    }

    protected void FixedUpdate()
    {
        if (!_isAttack)
            StartCoroutine(SpearAttackCoroutine());
    }

    private IEnumerator SpearAttackCoroutine()
    {
        transform.position = Player.Instance.transform.position;
        _isAttack = true;
        var attackTime = 5f;
        EffectToTargetInRadius();
        while (attackTime > 0f)
        {
            attackTime -= Time.deltaTime;
            transform.position += (Vector3)(_direction * _speed * Time.fixedDeltaTime);
            yield return null;
        }
        _isAttack = false;
    }
}

using UnityEngine;

public class SpearMovement : ProjectileMovement
{
    [SerializeField] private SpearController spearController;
    public Vector2 Direction => _direction;

    protected override void FixedUpdate() { }

    private void OnEnable()
    {
        spearController.onAttack += SpearController_onAttack;
    }

    private void OnDisable()
    {
        spearController.onAttack -= SpearController_onAttack;
    }

    private void SpearController_onAttack(object sender, System.EventArgs e)
    {
        GetTargetVector(spearController.TargetDirection, Player.Instance.Damage);
    }
}

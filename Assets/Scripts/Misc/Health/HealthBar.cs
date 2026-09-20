public class HealthBar : AbstractGenericProgressBar<Health>
{
    private void OnEnable()
    {
        targetObject.onHealthUp += TargetHealth_onHealthChanged;
        targetObject.onHealthDown += TargetHealth_onHealthChanged;
    }

    private void Start()
    {
        targetNormalized = targetObject.GetNormalizedHealth();
    }

    private void OnDisable()
    {
        targetObject.onHealthUp -= TargetHealth_onHealthChanged;
        targetObject.onHealthDown -= TargetHealth_onHealthChanged;
    }

    private void TargetHealth_onHealthChanged(object sender, System.EventArgs e)
    {
        targetNormalized = targetObject.GetNormalizedHealth();
    }
}
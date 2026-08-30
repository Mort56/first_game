using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthCount;
    [SerializeField] private Health targetHealth;
    [SerializeField] private float changeSpeed;
    private float targetNormalizedHealth;

    private void Awake()
    {
        healthCount.fillAmount = 0f;
    }

    private void OnEnable()
    {
        targetHealth.onHealthUp += TargetHealth_onHealthChanged;
        targetHealth.onHealthDown += TargetHealth_onHealthChanged;
    }

    private void Start()
    {
        targetNormalizedHealth = targetHealth.GetNormalizedHealth();
    }

    private void OnDisable()
    {
        targetHealth.onHealthUp -= TargetHealth_onHealthChanged;
        targetHealth.onHealthDown -= TargetHealth_onHealthChanged;
    }

    private void TargetHealth_onHealthChanged(object sender, System.EventArgs e)
    {
        targetNormalizedHealth = targetHealth.GetNormalizedHealth();
    }

    private void Update()
    {
        healthCount.fillAmount = Mathf.MoveTowards(healthCount.fillAmount, targetNormalizedHealth, changeSpeed * Time.deltaTime);
    }
}
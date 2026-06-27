using System.Collections;
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
        targetHealth.onTakeHit += TargetHealth_onTakeHit;
    }

    private void Start()
    {
        targetNormalizedHealth = targetHealth.getNormalizedHealth();
    }

    private void OnDisable()
    {
        targetHealth.onTakeHit -= TargetHealth_onTakeHit;
    }

    private void TargetHealth_onTakeHit(object sender, System.EventArgs e)
    {
        targetNormalizedHealth = targetHealth.getNormalizedHealth();
    }

    private void Update()
    {
        healthCount.fillAmount = Mathf.MoveTowards(healthCount.fillAmount, targetNormalizedHealth, changeSpeed * Time.deltaTime);
    }
}
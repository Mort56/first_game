using UnityEngine;

public class HealthVFX : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private Health objectHealth;

    private void OnEnable()
    {
        objectHealth.onHealthUp += ObjectHealth_onHealthUp;
    }

    private void OnDisable()
    {
        objectHealth.onHealthUp -= ObjectHealth_onHealthUp;
    }

    private void ObjectHealth_onHealthUp(object sender, System.EventArgs e)
    {
        particleSystem.Play();
    }
}

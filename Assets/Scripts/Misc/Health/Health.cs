using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float currentHealth;

    public event EventHandler onHealthChanges;
    public event EventHandler onTakeHit;

    private void Awake()
    {
        currentHealth = maxHealth;
    }
    
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
            currentHealth = 0;
        onHealthChanges?.Invoke(this, EventArgs.Empty);
        onTakeHit?.Invoke(this, EventArgs.Empty);
    }

    public void TakeHealth(float value)
    {
        currentHealth += value;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        onHealthChanges?.Invoke(this, EventArgs.Empty);
    }

    

    public float getNormalizedHealth()
    {
        return currentHealth / maxHealth;
    }
}
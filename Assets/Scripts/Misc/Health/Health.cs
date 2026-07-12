using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float _currentHealth;

    public event EventHandler onHealthChanges;
    public event EventHandler onTakeHit;

    private void Awake()
    {
        _currentHealth = maxHealth;
    }
    
    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth < 0)
            _currentHealth = 0;
        onHealthChanges?.Invoke(this, EventArgs.Empty);
        onTakeHit?.Invoke(this, EventArgs.Empty);
    }

    public void TakeHealth(float value)
    {
        _currentHealth += value;
        if (_currentHealth > maxHealth)
            _currentHealth = maxHealth;
        onHealthChanges?.Invoke(this, EventArgs.Empty);
    }



    public float getNormalizedHealth()
    {
        return _currentHealth / maxHealth;
    }

    public void ChangeMaxHealth(float newMaxHealth)
    {
        maxHealth = newMaxHealth;
        _currentHealth = maxHealth;
    }
}
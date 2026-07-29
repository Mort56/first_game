using System;
using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float _currentHealth;
    private float _dieTime = 0.15f;

    public event EventHandler OnHealthChanges;
    public event EventHandler OnTakeHit;

    private void Awake()
    {
        _currentHealth = maxHealth;
    }
    
    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth < 0)
            _currentHealth = 0;
        OnHealthChanges?.Invoke(this, EventArgs.Empty);
        OnTakeHit?.Invoke(this, EventArgs.Empty);
        if (_currentHealth <= 0)
            StartCoroutine(DieCoroutine());
    }

    public void TakeHealth(float value)
    {
        _currentHealth += value;
        if (_currentHealth > maxHealth)
            _currentHealth = maxHealth;
        OnHealthChanges?.Invoke(this, EventArgs.Empty);
    }

    public float GetNormalizedHealth()
    {
        return _currentHealth / maxHealth;
    }

    public void ChangeMaxHealth(float newMaxHealth)
    {
        maxHealth = newMaxHealth;
        _currentHealth = maxHealth;
    }

    private IEnumerator DieCoroutine()
    {
        yield return new WaitForSeconds(_dieTime);
        gameObject.SetActive(false);
    }
}
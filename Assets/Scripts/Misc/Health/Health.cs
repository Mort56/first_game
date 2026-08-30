using System;
using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float _currentHealth;
    private float _deathDuration = 0.15f;
    private WaitForSeconds _waitDeathDuration;

    public event EventHandler onHealthUp;
    public event EventHandler onHealthDown;

    private void Awake()
    {
        _waitDeathDuration = new WaitForSeconds(_deathDuration);
        _currentHealth = maxHealth;
    }
    
    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth < 0)
            _currentHealth = 0;
        onHealthDown?.Invoke(this, EventArgs.Empty);
        if (_currentHealth <= 0)
            StartCoroutine(DieCoroutine());
    }

    public void TakeHealth(float value)
    {
        _currentHealth += value;
        if (_currentHealth > maxHealth)
            _currentHealth = maxHealth;
        onHealthUp?.Invoke(this, EventArgs.Empty);
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
        yield return _waitDeathDuration;
        gameObject.SetActive(false);
    }
}
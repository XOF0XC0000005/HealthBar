using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    private const float HealthAmount = 0.1f;

    private float _maxHealth;
    private float _currentHealth;
    public UnityAction<float> _changedHealth;

    private void Awake()
    {
        _maxHealth = 1;
        _currentHealth = 0;
    }

    public float MaxAmount => _maxHealth;
    public float CurrentHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = value; }
    }
    public UnityAction<float> ChangedHealth { get; set; }

    public void Increase(float healthAmount)
    {
        _currentHealth += healthAmount;
        ChangedHealth.Invoke(_currentHealth);
    }

    public void Decrease(float healthAmount)
    {
        _currentHealth -= healthAmount;
        ChangedHealth.Invoke(_currentHealth);
    }
}

using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    private float _maxHealth;
    private float _currentHealth;

    public float MaxAmount => _maxHealth;

    public float CurrentHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = value; }
    }

    public UnityAction<float> ChangedHealth { get; set; }

    private void Awake()
    {
        _maxHealth = 1;
        _currentHealth = 0;
    }

    public void Increase(float healthAmount)
    {
        _currentHealth += healthAmount;
        ChangedHealth?.Invoke(_currentHealth);
    }

    public void Decrease(float healthAmount)
    {
        _currentHealth -= healthAmount;
        ChangedHealth?.Invoke(_currentHealth);
    }
}

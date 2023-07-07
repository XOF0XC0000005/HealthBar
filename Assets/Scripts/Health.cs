using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    private const float HealthAmount = 0.1f;

    private float _maxHealth;
    private float _currentHealth;
    public UnityEvent _changedHealth = new UnityEvent();

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
    public UnityEvent ChangedHealth
    {
        get { return _changedHealth; }
        set { _changedHealth = value; }
    }

    public void Increase()
    {
        _currentHealth += HealthAmount;
    }

    public void Decrease()
    {
        _currentHealth -= HealthAmount;
    }
}

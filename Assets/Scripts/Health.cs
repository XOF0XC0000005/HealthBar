using UnityEngine;

public class Health : MonoBehaviour
{
    private const float HealthAmount = 0.1f;
    private float _maxHealth;
    private float _currentHealth;

    public Health()
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

    public float GetHeal()
    {
        return _currentHealth += HealthAmount;
    }

    public float GetDamage()
    {
        return _currentHealth -= HealthAmount;
    }
}

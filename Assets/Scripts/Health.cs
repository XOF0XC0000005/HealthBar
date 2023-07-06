public class Health
{
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
}

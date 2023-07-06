using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class UpdateHealthBar : MonoBehaviour
{
    private const float _HealthAmount = 0.1f;
    private const float _ValueSpeed = 0.001f;
    private Slider _healthbar;
    private Health _health;

    private void Awake()
    {
        _healthbar = GetComponent<Slider>();
        _health = new Health();
    }

    private void Update()
    {
        _healthbar.value = Mathf.MoveTowards(_healthbar.value, _health.CurrentHealth, _ValueSpeed);
    }

    public void GetHeal()
    {
        _health.CurrentHealth += _HealthAmount;
    }
    
    public void GetDamage()
    {
        _health.CurrentHealth -= _HealthAmount;
    }
}

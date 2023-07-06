using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
[RequireComponent(typeof(Health))]

public class UpdateHealthBar : MonoBehaviour
{
    private const float _ValueSpeed = 0.001f;
    private Coroutine _lastRoutine;
    private Slider _healthbar;
    private Health _health;

    private void Awake()
    {
        _healthbar = GetComponent<Slider>();
        _health = GetComponent<Health>();
        _lastRoutine = null;
    }

    private IEnumerator IncreaseSlider()
    {
        float targetHealthValue = _health.GetHeal();

        while (_healthbar.value != targetHealthValue)
        {
            _healthbar.value = Mathf.MoveTowards(_healthbar.value, targetHealthValue, _ValueSpeed);
            yield return null;
        }
    }

    private IEnumerator DecreaseSlider()
    {
        float targetHealthValue = _health.GetDamage();

        while (_healthbar.value != targetHealthValue)
        {
            _healthbar.value = Mathf.MoveTowards(_healthbar.value, targetHealthValue, _ValueSpeed);
            yield return null;
        }
    }

    public void Healing()
    {
        if (_lastRoutine != null)
        {
            StopCoroutine(_lastRoutine);
            _lastRoutine = null;
            _lastRoutine = StartCoroutine(IncreaseSlider());
        }
        else
        {
            _lastRoutine = StartCoroutine(IncreaseSlider());
        }
    }

    public void Damaging()
    {
        if (_lastRoutine != null)
        {
            StopCoroutine(_lastRoutine);
            _lastRoutine = null;
            _lastRoutine = StartCoroutine(DecreaseSlider());
        }
        else
        {
            _lastRoutine = StartCoroutine(DecreaseSlider());
        }
    }
}

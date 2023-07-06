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

    private IEnumerator ManipulateSlider()
    {
        while (_healthbar.value != _health.CurrentHealth)
        {
            _healthbar.value = Mathf.MoveTowards(_healthbar.value, _health.CurrentHealth, _ValueSpeed);
            yield return null;
        }
    }

    public void Healing()
    {
        _health.ChangedHealth.AddListener(_health.Increase);
        _health.ChangedHealth.Invoke();

        if (_lastRoutine != null)
        {
            StopCoroutine(_lastRoutine);
            _lastRoutine = null;
        }
       
        _lastRoutine = StartCoroutine(ManipulateSlider());
        _health.ChangedHealth.RemoveListener(_health.Increase);
    }

    public void Damaging()
    {
        _health.ChangedHealth.AddListener(_health.Decrease);
        _health.ChangedHealth.Invoke();

        if (_lastRoutine != null)
        {
            StopCoroutine(_lastRoutine);
            _lastRoutine = null;
        }

        _lastRoutine = StartCoroutine(ManipulateSlider());
        _health.ChangedHealth.RemoveListener(_health.Decrease);
    }
}

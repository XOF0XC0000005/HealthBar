using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
[RequireComponent(typeof(Health))]

public class HealthBar : MonoBehaviour
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

    private void MakeAction(UnityAction action)
    {
        _health.ChangedHealth.AddListener(action);
        _health.ChangedHealth.Invoke();

        if (_lastRoutine != null)
        {
            StopCoroutine(_lastRoutine);
            _lastRoutine = null;
        }

        _lastRoutine = StartCoroutine(ManipulateSlider());
        _health.ChangedHealth.RemoveListener(action);
    }

    public void Healing()
    {
        MakeAction(_health.Increase);
    }

    public void Damaging()
    {
        MakeAction(_health.Decrease);
    }
}

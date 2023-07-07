using System;
using System.Collections;
using UnityEngine;
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
        _health.ChangedHealth += MakeAction;
        _lastRoutine = null;
    }

    private void OnDestroy()
    {
        _health.ChangedHealth -= MakeAction;
    }

    private IEnumerator ManipulateSlider(float targetHealth)
    {
        while (_healthbar.value != targetHealth)
        {
            _healthbar.value = Mathf.MoveTowards(_healthbar.value, targetHealth, _ValueSpeed);
            yield return null;
        }
    }

    private void MakeAction(float value)
    {
        if (_lastRoutine != null)
        {
            StopCoroutine(_lastRoutine);
            _lastRoutine = null;
        }

        _lastRoutine = StartCoroutine(ManipulateSlider(value));
    }
}

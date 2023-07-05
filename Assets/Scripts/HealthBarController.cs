using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBarController : MonoBehaviour
{
    private Slider healthbar;
    private Health health;
    private int healthAmount = 10;

    private void Awake()
    {
        healthbar = GetComponent<Slider>();
        health = new Health(100);
        healthbar.maxValue = health.HealthAmount;
    }

    public void GetHeal() => healthbar.value += healthAmount;
    public void GetDamage() => healthbar.value -= healthAmount;
}

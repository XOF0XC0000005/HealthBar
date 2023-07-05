using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    private int healthAmount;

    public Health(int health)
    {
        healthAmount = health;
    }

    public int HealthAmount => healthAmount;
}

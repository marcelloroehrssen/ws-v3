using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float maxHealth = 10;
    public float health = 10;

    public void Damage(float damage)
    {
        health -= health;
    }
}

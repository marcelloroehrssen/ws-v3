﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public float damage = 1;

    private bool canDamage = true;

    public void IsDead()
    {
        canDamage = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject go = collision.gameObject;
        if (go.tag == "Player")
        {
            CharacterStats stats = go.GetComponent<CharacterStats>();
            if (stats != null && canDamage)
            {
                stats.Damage(damage);
            }
        }
    }
}

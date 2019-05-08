using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    private float maxHealth = 10;
    private float health = 10;

    public RectTransform healthBar;

    public void Damage(float damage)
    {
        health -= damage;
        healthBar.sizeDelta = new Vector2(health / maxHealth * 200, 10);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

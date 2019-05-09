using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    public float maxHealth = 10;
    private float health = 10;

    public RectTransform healthBar;
    public RectTransform healthBarContainer;

    public void Buff(float health)
    {
        maxHealth += health;
    }

    public void Damage(float damage)
    {
        health -= damage;
        healthBar.sizeDelta = new Vector2(health / maxHealth * healthBarContainer.sizeDelta.x, healthBarContainer.sizeDelta.y);

        if (health <= 0)
        {
            GetComponent<Animator>().SetTrigger("IsDead");
        }
    }

    public void IsDead()
    {
        Destroy(gameObject);
    }
}

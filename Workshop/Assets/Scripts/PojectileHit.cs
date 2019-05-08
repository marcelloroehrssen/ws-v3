using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PojectileHit : MonoBehaviour
{
    public float damage = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(gameObject);
            if (collision.GetComponent<EnemyStats>() != null)
            {
                EnemyStats es = collision.GetComponent<EnemyStats>();
                es.Damage(damage);
            }
        } else if(collision.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }
}

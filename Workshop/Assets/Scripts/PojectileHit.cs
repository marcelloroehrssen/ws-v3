using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PojectileHit : MonoBehaviour
{
    private float damage = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}

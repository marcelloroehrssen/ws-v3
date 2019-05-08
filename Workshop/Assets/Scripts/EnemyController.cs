﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform target;

    public float speed = 3f;

    [Min(1)]
    public float seekingThreshold = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) > seekingThreshold)
        {
            Vector3 dir = target.position - transform.position;
            dir.Normalize();

            transform.Translate(dir * speed * Time.deltaTime);
        }
    }
}

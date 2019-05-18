﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotator : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);

        lookPos = lookPos - transform.position;
        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;

        if (Mathf.Abs(angle) > 90)
        {
            GetComponentInChildren<SpriteRenderer>().flipY = true;
        } else
        {
            GetComponentInChildren<SpriteRenderer>().flipY = false;
        }

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}

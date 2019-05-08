﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [Range(1, 10)]
    public float speed = 1f;
    [Range(1, 600)]
    public float speedJump = 1f;

    private bool isGrounded = true;
    private bool hasJumped = false;
    private Rigidbody2D rb2d;


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (!isGrounded && rb2d.velocity.y == 0 && hasJumped == false)
        {
            isGrounded = true;
        }
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            hasJumped = true;
        }
    }

    private void FixedUpdate()
    {
        if (hasJumped)
        {
            rb2d.AddForce(transform.up * speedJump);
            hasJumped = false;
            isGrounded = false;
        }
    }
}

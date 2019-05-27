using System.Collections;
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
    private Animator animator;
    private AudioSource audioSourceJump;
    private AudioSource audioSourceLand;


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSourceJump = GetComponents<AudioSource>()[2];
        audioSourceLand = GetComponents<AudioSource>()[3];
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("IsWalkingLeft", false);
        animator.SetBool("IsWalkingRight", false);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            animator.SetBool("IsWalkingLeft", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            animator.SetBool("IsWalkingRight", true);
        }

        if (!isGrounded && rb2d.velocity.y == 0 && hasJumped == false)
        {
            audioSourceLand.Play();
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
            audioSourceJump.Play();
            rb2d.AddForce(transform.up * speedJump);
            hasJumped = false;
            isGrounded = false;
        }
    }
}

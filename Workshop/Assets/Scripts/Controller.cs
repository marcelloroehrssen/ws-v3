using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [Range(1, 10)]
    public float speed = 1f;
    [Range(1, 600)]
    public float speedJump = 1f;

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
        if (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * speedJump);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(Vector3.down * speedJump * Time.deltaTime);
        }
    }
}

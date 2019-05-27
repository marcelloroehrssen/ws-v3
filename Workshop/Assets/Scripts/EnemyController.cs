using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform target;

    public float speed = 3f;

    [Min(1)]
    public float seekingThreshold = 1f;

    private bool isFacingLeft = false;

    public void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Player")[0].transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) > seekingThreshold)
        {
            Vector3 dir = target.position - transform.position;
            dir.Normalize();
            
            if (!isFacingLeft && transform.position.x > target.position.x)
            {
                isFacingLeft = true;
                GetComponent<Animator>().transform.Rotate(0, 180, 0);
            } else if (isFacingLeft && transform.position.x < target.position.x)
            {
                isFacingLeft = false;
                GetComponent<Animator>().transform.Rotate(0, 180, 0);
            }
            dir.x = Mathf.Abs(dir.x);

            GetComponent<Animator>().SetBool("IsWalking", true);
            Debug.Log(Time.deltaTime);
            transform.Translate(dir * speed * Time.deltaTime);
        } else
        {
            GetComponent<Animator>().SetBool("IsWalking", false);
        }
    }
}

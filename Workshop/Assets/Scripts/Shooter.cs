using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Shooter : MonoBehaviour
{
    public GameObject projectile;
    [Range(1,50)]
    public float projectileSpeed = 10f;
    [Range(1,20)]
    public int maxProjectile = 3;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        int currentProjectile = GameObject.FindGameObjectsWithTag("Projectile").Length;

        if (Input.GetMouseButtonDown(0) && currentProjectile < maxProjectile)
        {
            Vector3 rot = transform.rotation.eulerAngles * Mathf.Deg2Rad;
            Vector3 dir = new Vector3(Mathf.Cos(rot.z),  Mathf.Sin(rot.z));
            dir.Normalize();

            GameObject proj = Instantiate(projectile);
            proj.transform.position = transform.position;
            proj.transform.rotation = transform.rotation;
            proj.GetComponent<Rigidbody2D>().AddForce(
                dir * projectileSpeed,
                ForceMode2D.Impulse
            );
            audioSource.Play();
        }
    }
}

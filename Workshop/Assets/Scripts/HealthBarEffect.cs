using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarEffect : MonoBehaviour
{
    public float speed = .3f;
    
    private float t = 0;
    private float valToBeLerped = 0;
    

    // Update is called once per frame
    void Update()
    {
        if (t < 1)
        {
            t += Time.deltaTime * speed;
            valToBeLerped = Mathf.Lerp(0.01f, 0.99f, t);
            GetComponent<Image>().material.SetFloat("_Middle", valToBeLerped);
        } else
        {
            t = 0;
        }
    }
}

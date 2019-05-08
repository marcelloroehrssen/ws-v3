using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyer : MonoBehaviour
{
    [Range(.1f, 2f)]
    public float ttl = .8f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("UpdateLivingTime");
    }

    // Update is called once per frame
    IEnumerator UpdateLivingTime()
    {
        yield return new WaitForSeconds(ttl);
        Destroy(gameObject);
    }
}

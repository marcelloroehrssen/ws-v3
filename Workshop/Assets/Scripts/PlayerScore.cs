using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public void IsDead()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");
        if (gos.Length == 0)
        {
            return;
        }
        CharacterStats stats = gos[0].GetComponent<CharacterStats>();
        stats.IncrementScore(1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;

    public float spawnTime = 2f;
    public float buffCycle = 2f;
    public float incrementCycle = 2f;

    private int spawnCycle = 0;
    private int enemyToSpawn = 1;
    
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, spawnTime);
    }

    void SpawnEnemy()
    {
        if (spawnCycle % incrementCycle == 0)
        {
            enemyToSpawn++;
        }
        for (int i = 0; i < enemyToSpawn; i++) {
            GameObject go = Instantiate(enemy);
            go.transform.position = transform.position;
            if (spawnCycle % buffCycle == 0) {
                if (go.GetComponent<EnemyStats>() != null)
                {
                    go.GetComponent<EnemyStats>().Buff(spawnCycle);
                }
            }
        }
        spawnCycle++;
    }
}

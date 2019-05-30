using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public EnemyChooser chooser;

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
        if (GameObject.FindGameObjectsWithTag("Enemy").Length != 0)
        {
            return;
        }
        Debug.Log("Wave Destroied");
        if (spawnCycle % incrementCycle == 0)
        {
            enemyToSpawn++;
        }
        Debug.Log($"Spawning {enemyToSpawn} enemy");
        for (int i = 0; i < enemyToSpawn; i++) {
            Debug.Log("Spawning Enemy");
            GameObject go = Instantiate(chooser.Pick());
            go.transform.position = transform.position;
            if (spawnCycle % buffCycle == 0) {
                if (go.GetComponent<CharacterStats>() != null)
                {
                    go.GetComponent<CharacterStats>().Buff(spawnCycle);
                }
            }
        }
        spawnCycle++;
    }
}

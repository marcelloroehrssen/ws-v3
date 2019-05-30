using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyChooser : MonoBehaviour
{
    public List<EnemyLevelConfig> configurations;

    public GameObject defaultEnemy;

    public GameObject Pick()
    {
        foreach (EnemyLevelConfig config in configurations) 
        {
            if (config.index == SceneManager.GetActiveScene().buildIndex)
            {
                if (config.randomize)
                {
                    return config.enemies[UnityEngine.Random.Range(0, config.enemies.Count)];
                } else
                {
                    return config.defaultEnemy;
                }
            }
        }
        return defaultEnemy;
    }

    [Serializable]
    public class EnemyLevelConfig
    {
        [SerializeField]
        public bool randomize = true;

        public int index;

        public List<GameObject> enemies;

        [SerializeField]
        public GameObject defaultEnemy;
    }
}

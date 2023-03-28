using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private float spawnInterval;
    private bool startSpawn = false;

    void Start()
    {
        
    }
    // void Update()
    // {
    //     if(startSpawn == true)
    //     {
    //         InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    //     }
    // }
    public void StartSpawnEnemies()
    {
        startSpawn = true;
        StartCoroutine(SpawnEnemies());
    }
    // public void SpawnEnemy()
    // {
    //     foreach (Transform spawnPosition in spawnPositions)
    //     {
    //         float randomChance = Random.Range(0f, 1f);
    //         if (randomChance < 0.5f)
    //         {
    //             Instantiate(enemyPrefab, spawnPosition.position, Quaternion.identity);
    //         }
    //     }
    // }
    public void ResetSpawning()
    {
        startSpawn = false;
    }
    IEnumerator SpawnEnemies()
    {
        if(startSpawn == true)
        {
            foreach (Transform spawnPosition in spawnPositions)
            {
                float randomChance = Random.Range(0f, 1f);
                if (randomChance < 0.5f)
                {
                    Instantiate(enemyPrefab, spawnPosition.position, Quaternion.identity);
                }
            }
            yield return new WaitForSeconds(spawnInterval);
            StartCoroutine(SpawnEnemies());
        }
    }
}

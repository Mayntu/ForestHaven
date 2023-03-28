using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    public GameObject[] treePrefabs;
    public int maxTrees = 10;
    public float spawnRadius = 5f;
    public float refillTime;
    public float treeOffset = 2f;
    
    [SerializeField] private int currentTreeCount;
    private Vector2 lastSpawnedPosition;

    void Start() 
    {
        currentTreeCount = 0;
        SpawnTrees();
    }

    void SpawnTrees () {
        while (currentTreeCount < maxTrees) 
        {
            int index = Random.Range(0, treePrefabs.Length);
            Vector2 spawnPos = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;

            // Add random offset to x and y coordinates of spawn position
            float xOffset = Random.Range(-1f, 1f) * treeOffset;
            float yOffset = Random.Range(-1f, 1f) * treeOffset;
            spawnPos += new Vector2(xOffset, yOffset);
            bool canSpawn = true;

            if(canSpawn)
            {
                Instantiate(treePrefabs[index], spawnPos, Quaternion.identity);
                currentTreeCount++;
            }
        }
    }

    public void CutDownTree() 
    {
        currentTreeCount--;
        StartCoroutine(RefillTree());
    }
    IEnumerator RefillTree() 
    {
        yield return new WaitForSeconds(refillTime);
        SpawnTrees();
    }
}

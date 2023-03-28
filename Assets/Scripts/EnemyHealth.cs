using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;
    [SerializeField]private int currentHealth, maxHealth;
    [SerializeField] private bool isDead = false;
    [SerializeField] private GameObject smallCoinPrefab, midCoinPrefab, bigCoinPrefab;
    [SerializeField] private int smallCoinCount, midCoinCount, bigCoinCount;
    [SerializeField] private float coinSpawnRadius = 1f;
    [SerializeField] private Transform coinSpawnArea;
    [SerializeField] private ParticleSystem particles;
    public void InitializeHealth(int healthValue)
    {
        currentHealth = healthValue;
        maxHealth = healthValue;
        isDead = false;
    }

    public void GetHit(int amount, GameObject sender)
    {
        if (isDead)
            return;
        if (sender.layer == gameObject.layer)
            return;

        currentHealth -= amount;

        if (currentHealth > 0)
        {
            OnHitWithReference?.Invoke(sender);
        }
        else
        {
            OnDeathWithReference?.Invoke(sender);
            isDead = true;
            StartCoroutine(DoDeath());
        }
    }
    private IEnumerator DoDeath()
    {
        GoblinEnemyMovement goblinEnemyMovement;
        goblinEnemyMovement = gameObject.GetComponent<GoblinEnemyMovement>();
        Destroy(goblinEnemyMovement);
        for (int i = 0; i < smallCoinCount; i++)
        {
            SpawnCoins(smallCoinPrefab);
        }
        for (int i = 0; i < midCoinCount; i++)
        {
            SpawnCoins(midCoinPrefab);
        }
        for (int i = 0; i < bigCoinCount; i++)
        {
            SpawnCoins(bigCoinPrefab);
        }
        particles.Play();
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
    private void SpawnCoins(GameObject prefab)
    {
        Vector3 randomPos = Random.insideUnitCircle * coinSpawnRadius;
        Instantiate(prefab, randomPos + transform.position, Quaternion.identity);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(coinSpawnArea.transform.position, coinSpawnRadius);
    }
}
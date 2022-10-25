using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnRadius;

    [SerializeField] private GameObject zombiePrefab;
    [SerializeField] private GameObject bosszombiePrefab;

    [Header("SpawnTime")]
    [SerializeField] private float zombieInterval;
    [SerializeField] private float bosszombieInterval;

    
    private float zombieDelay;
    private float bosszombieDelay;
    private void Start()
    {
        zombieDelay = zombieInterval;
        bosszombieDelay = bosszombieInterval;

        Spawner();
        
    }

    private IEnumerator spawnEnemy(float period, GameObject enemy)
    {
        Vector2 spawnPosition = GameObject.Find("Player").transform.position;
        spawnPosition += Random.insideUnitCircle.normalized * spawnRadius;

        yield return new WaitForSeconds(period);
        GameObject newEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
        StartCoroutine(spawnEnemy(period, enemy));
    }

    private void Spawner()
    {
        StartCoroutine(spawnEnemy(zombieDelay, zombiePrefab));
        StartCoroutine(spawnEnemy(bosszombieDelay, bosszombiePrefab));
    }
}

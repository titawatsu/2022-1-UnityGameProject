using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnRadius;

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject bossPrefab;

    [Header("SpawnTime")]
    [SerializeField] private float enemyInterval;
    [SerializeField] private float bossInterval;

    
    private float enemyDelay;
    private float bossDelay;
    private void Start()
    {
        enemyDelay = enemyInterval;
        bossDelay = bossInterval;

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
        StartCoroutine(spawnEnemy(enemyDelay, enemyPrefab));
        StartCoroutine(spawnEnemy(bossDelay, bossPrefab));
    }
}

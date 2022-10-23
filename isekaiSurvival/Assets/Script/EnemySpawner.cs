using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject zombiePrefab;
    [SerializeField] private GameObject bosszombiePrefab;

    [SerializeField] private float zombieInterval;
    [SerializeField] private float bosszombieInterval;
    private void Start()
    {
        Spawner();
    }

    private IEnumerator spawnEnemy(float period, GameObject enemy)
    {
        yield return new WaitForSeconds(period);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-20, 20f), Random.Range(-24, 24f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(period, enemy));
    }

    private void Spawner()
    {
        StartCoroutine(spawnEnemy(zombieInterval, zombiePrefab));
        StartCoroutine(spawnEnemy(bosszombieInterval, bosszombiePrefab));
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject playerObj;
    [SerializeField] private GameObject lootPrefab;

    [SerializeField] private float enemySpeed;
    [SerializeField] private float distance;
    [SerializeField] private float distanceBetween;

    //[SerializeField] private CircleCollider2D circleCollider;



    private void Awake()
    {

        playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        findDirection();
    }

    #region ENEMY_MOVEMENT
    private void findDirection()
    {
        distance = Vector2.Distance(transform.position, playerObj.transform.position);
        Vector2 direction = playerObj.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, playerObj.transform.position, enemySpeed * Time.deltaTime);
            transform.rotation = Quaternion.AngleAxis(angle + 90f, Vector3.forward);
            //Quaternion.Euler(Vector3.forward * angle); didnt use due to weird rotation
        }
    }
    #endregion
    #region COLLISION
    private void OnTriggerEnter2D(Collider2D circleCollider)
    {
        if (circleCollider.CompareTag("Player"))
        {
            if (circleCollider.gameObject.TryGetComponent<HealthWevent>(out var health))
            {
                health.Damage(1);
                StartCoroutine(DelayHit());
            }
        }
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private IEnumerator DelayHit()
    {
        yield return new WaitForSeconds(2);

    }

    #endregion



    public void LootDrop()
    {
        var RandChance = Random.Range(0, 10);
        if (RandChance == 5) Instantiate(lootPrefab, transform.position, Quaternion.identity);
    }
}

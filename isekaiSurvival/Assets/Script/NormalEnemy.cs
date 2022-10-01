using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : MonoBehaviour
{
    [SerializeField] private GameObject playerObj;

    [SerializeField] private float enemySpeed;
    [SerializeField] private float distance;
    [SerializeField] private float distanceBetween;

    private void Awake()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        findDirection();
    }

    private void findDirection()
    {
        distance = Vector2.Distance(transform.position, playerObj.transform.position);
        Vector2 direction = playerObj.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, playerObj.transform.position, enemySpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle );
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}

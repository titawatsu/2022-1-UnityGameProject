using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletObject : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float bulletSpeed = 10f;

    private float selfdestroyDelay = 3f;

    
    private void Start()
    {
        rb.velocity = transform.up * bulletSpeed;
        Destroy(gameObject, selfdestroyDelay);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<HealthWevent>(out var health))
        {
            health.Damage(5);
        }
        Destroy(gameObject);

    }
}

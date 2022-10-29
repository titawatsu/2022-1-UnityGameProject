using Samplebank;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    private Collider2D playerCollider;
    private void Start()
    {
        playerCollider = GetComponent<Collider2D>(); // get player colider from its prefab
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out CircleCollider2D enemyCollider))
        {
            var magnitude = 5000;

            var force = transform.position - collision.transform.position;

            force.Normalize();
            GetComponent<Rigidbody2D>().AddForce(force * magnitude);
            // to create force that push player beck from enemy
        }

        if (collision.TryGetComponent(out ItemClass itemClass))
        {
            var itemType = itemClass.GetItemInfoOnContact();

            switch (itemType)
            {
                case ItemType.SpeedBoost:
                    playerController.EnableBoostSpeed();
                    break;
                default:
                    break;
            }
            //to check item type that player collected 

            Debug.Log(itemType);
        }
    }

    
}
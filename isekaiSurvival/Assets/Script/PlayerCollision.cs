using Samplebank;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    //[SerializeField] private PlayerAudioController audioController;

    //[SerializeField] private ParticleSystem dustDeath;

    private Collider2D playerCollider;
    private void Start()
    {
        playerCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
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

            Debug.Log(itemType);
        }
    }
}
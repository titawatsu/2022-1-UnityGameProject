using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClass : MonoBehaviour
{
    
    //[SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private SoItem Soitem;


    private ItemType itemType;

    private void Start()
    {
        SetCollectible();
        
    }

    public ItemType GetItemInfoOnContact()
    {
        gameObject.SetActive(false);

        return itemType;
    }

    private void SetCollectible()
    {
        
        itemType = Soitem.GetCollectibleType();
        
    }
}

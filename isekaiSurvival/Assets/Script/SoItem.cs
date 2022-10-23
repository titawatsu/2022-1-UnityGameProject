using UnityEngine;

[CreateAssetMenu(menuName = "Collectibles", fileName = "New Collectible")]
public class SoItem : ScriptableObject
{
    [SerializeField] private ItemType itemType;
    [SerializeField] private Sprite sprite;
    
    public Sprite GetSprite() => sprite;
    public ItemType GetCollectibleType() => itemType;
    
}

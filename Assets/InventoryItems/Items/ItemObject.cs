
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Item", menuName = "Inventory System/Item")]
public class ItemObject : InventoryItemObjectAbstract
{
    [TextArea (5, 10)]
    public string Description;
    public Sprite Image;
    void Awake()
    {
        ItemType = ItemType.Item;
    }    
}

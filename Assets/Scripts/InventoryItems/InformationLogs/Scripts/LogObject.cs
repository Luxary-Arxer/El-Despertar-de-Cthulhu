using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Log", menuName = "Inventory System/Log")]
public class LogObject : InventoryItemObjectAbstract
{
    [TextArea (5, 10)]
    public string Log;
    public Sprite Image;
    void Awake()
    {
        ItemType = ItemType.Log;
    }    
}

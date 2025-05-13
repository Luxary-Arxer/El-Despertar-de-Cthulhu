
using UnityEngine;

public enum ItemType {
    Hint,
    Item,
    Log
}

public abstract class InventoryItemObjectAbstract : ScriptableObject
{
    public ItemType ItemType;
    public string Name;
}

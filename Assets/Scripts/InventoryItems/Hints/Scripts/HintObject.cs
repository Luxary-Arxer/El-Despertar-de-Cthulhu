
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Hint", menuName = "Inventory System/Hint")]
public class HintObject : InventoryItemObjectAbstract
{
    [TextArea(5, 10)]
    public string Hint;   
}
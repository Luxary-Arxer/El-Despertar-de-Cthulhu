
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField]
    ItemObject _item;
    public ItemObject Item { get { return _item; } }
}

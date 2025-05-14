
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [Header("Starter items")]
    [SerializeField]
    ItemObject _daggerItem;

    [Header("Inventory slots")]
    [SerializeField]
    GameObject[] _itemSlots;
    public static List<ItemObject> ItemInventory = new();

    // public class Item
    // {
    //     public Sprite InventoryImage;
    //     public string Name;
    //     public string Description;
    //     public Item(Sprite img, string name, string desc)
    //     {
    //         InventoryImage = img;
    //         Name = name;
    //         Description = desc;
    //     }
    // }
    
    void OnEnable()
    {
        UpdateItemInventoryUI();
    }
    void Awake()
    {
        AddItemToInventory(_daggerItem);
    }
    public void AddItemToInventory(ItemObject item)
    {
        if (ItemInventory.Count < _itemSlots.Length)
        {
            ItemInventory.Add(item);

            UpdateItemInventoryUI();
        }
        else
        {
            Debug.Log("¡No hay espacio en el inventario!");
        }
    }
    void UpdateItemInventoryUI()
    {
        for (int i = 0; i < _itemSlots.Length && i < ItemInventory.Count; i++)
        {
            ItemSlotManager currentItem = _itemSlots[i].GetComponent<ItemSlotManager>();
            currentItem.ItemImage = ItemInventory[i].Image;
            currentItem.ItemName = ItemInventory[i].Name;
            currentItem.ItemDescription = ItemInventory[i].Description;
            currentItem.DisplayImageOnInventory();
        }
    }
}

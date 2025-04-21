
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [Header("Starter items")]
    [SerializeField]
    Sprite _itemImage;
    [SerializeField]
    string _itemName;
    [SerializeField]
    string _itemDescription;

    [Header("Inventory slots")]
    [SerializeField]
    GameObject[] _itemSlots;
    public List<Item> ItemInventory = new();

    public class Item
    {
        public Sprite InventoryImage;
        public string Name;
        public string Description;
        public Item(Sprite img, string name, string desc)
        {
            InventoryImage = img;
            Name = name;
            Description = desc;
        }
    }
    void OnEnable()
    {
        UpdateItemInventory();
    }
    void Awake()
    {
        AddItemToInventory(_itemImage, _itemName, _itemDescription);
    }
    public void AddItemToInventory(Sprite img, string name, string desc)
    {
        if (ItemInventory.Count < _itemSlots.Length)
        {
            Item newInventoryItem = new(img, name, desc);
            ItemInventory.Add(newInventoryItem);

            UpdateItemInventory();
        }
        else
        {
            Debug.Log("¡No hay espacio en el inventario!");
        }
    }
    void UpdateItemInventory()
    {
        for (int i = 0; i < _itemSlots.Length && i < ItemInventory.Count; i++)
        {
            ItemSlotManager currentItem = _itemSlots[i].GetComponent<ItemSlotManager>();
            currentItem.ItemImage = ItemInventory[i].InventoryImage;
            currentItem.ItemName = ItemInventory[i].Name;
            currentItem.ItemDescription = ItemInventory[i].Description;
            currentItem.DisplayImageOnInventory();
        }
    }
}

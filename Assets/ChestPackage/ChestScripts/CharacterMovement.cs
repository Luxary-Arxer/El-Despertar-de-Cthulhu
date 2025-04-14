using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    GameObject[] _itemSlots;
    public List<Item> Inventory = new();
    Collider _interactableObject;

    public class Item
    {
        public SpriteRenderer InventoryImage;
        public Item(SpriteRenderer img)
        {
            InventoryImage = img;
        }
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 currentPos = transform.position;
            currentPos.x += Time.deltaTime * 4;
            transform.position = new Vector3(currentPos.x, transform.position.y, currentPos.z);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 currentPos = transform.position;
            currentPos.x -= Time.deltaTime * 4;
            transform.position = new Vector3(currentPos.x, transform.position.y, currentPos.z);
        }
        if (Input.GetKeyDown(KeyCode.E) && _interactableObject != null)
        {
            string tag = _interactableObject.tag;
            switch (tag)
            {//lo hago con switch por si en el futuro el numero de interacciones sube más.
                case "Chest":
                    ChestInteraction();
                    break;
                case "Item":
                    ItemPickUp();
                    break;
            }
        }
    }
    void ChestInteraction()
    {
        ChestRandomAlgorithm chest = _interactableObject.GetComponentInParent<ChestRandomAlgorithm>();
        chest.OnChestOpen();
    }
    void ItemPickUp()
    {
        if (Inventory.Count < _itemSlots.Length)
        {
            CollectibleItemLogic pickedItem = _interactableObject.GetComponent<CollectibleItemLogic>();
            Item newInventoryItem = new(pickedItem.Image);
            Inventory.Add(newInventoryItem);
            pickedItem.OnItemPicked();
            RefreshInventoryUI();
        } else {
            Debug.Log("¡No hay espacio en el inventario!");
        }
    }
    void RefreshInventoryUI()
    {
        for (int i = 0; i < _itemSlots.Length && i < Inventory.Count; i++)
        {
            Image img = _itemSlots[i].GetComponent<Image>();
            img.sprite = Inventory[i].InventoryImage.sprite;
            Color imgColor = img.color;
            imgColor.a = 255;
            img.color = imgColor;
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        _interactableObject = collider;
    }
}

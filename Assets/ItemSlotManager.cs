
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _itemDescriptionBox;
    [SerializeField]
    TextMeshProUGUI _itemNameBox;

    SpriteRenderer _itemImage;
    string _itemName;
    string _itemDescription;
    public SpriteRenderer ItemImage { set { _itemImage = value; } }
    public string ItemName { set { _itemName = value; } }
    public string ItemDescription { set { _itemDescription = value; } }

    public void DisplayImageOnInventory()
    {
        GetComponentInChildren<Image>().sprite = _itemImage.sprite;
    }    
    public void DisplayItemDescription()
    {
        _itemDescriptionBox.text = _itemDescription;
        _itemNameBox.text = _itemName;
    }
}

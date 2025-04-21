
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotManager : MonoBehaviour
{
    [Header("UI elements")]
    [SerializeField]
    TextMeshProUGUI _itemDescriptionBox;
    [SerializeField]
    TextMeshProUGUI _itemNameBox;

    Sprite _itemImage;
    string _itemName;
    string _itemDescription;
    public Sprite ItemImage { set { _itemImage = value; } }
    public string ItemName { set { _itemName = value; } }
    public string ItemDescription { set { _itemDescription = value; } }

    public void DisplayImageOnInventory()
    {
        GetComponentInChildren<Image>().sprite = _itemImage;
    }    
    public void DisplayItemDescription()
    {
        _itemDescriptionBox.text = _itemDescription;
        _itemNameBox.text = _itemName;
    }
}

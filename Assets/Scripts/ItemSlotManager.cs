
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
    [SerializeField]
    Image _itemImageBox;

    Sprite _itemImage;
    string _itemName;
    string _itemDescription;
    public Sprite ItemImage { set { _itemImage = value; } }
    public string ItemName { set { _itemName = value; } }
    public string ItemDescription { set { _itemDescription = value; } }

    public void DisplayImageOnInventory()
    {
        _itemImageBox.sprite = _itemImage;
        
        Color imgColor = _itemImageBox.color;
        imgColor.a = 255;
        _itemImageBox.color = imgColor;
    }
    public void DisplayItemDescription()
    {
        _itemDescriptionBox.text = _itemDescription;
        _itemNameBox.text = _itemName;
    }
}

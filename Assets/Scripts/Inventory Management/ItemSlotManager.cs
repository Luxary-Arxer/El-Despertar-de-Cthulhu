
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
    GameObject _itemImageBox;

    Sprite _itemImage;
    string _itemName;
    string _itemDescription;

    public Sprite ItemImage { set { _itemImage = value; } }
    public string ItemName { set { _itemName = value; } }
    public string ItemDescription { set { _itemDescription = value; } }

    CharacterAudioManager _characterAudioManager;

    void Awake()
    {
        _characterAudioManager = FindFirstObjectByType<CharacterAudioManager>();
    }
    public void DisplayImageOnInventory()
    {
        if (!ComponentHasImage())
        {
            _itemImageBox.AddComponent<Image>();
        }

        _itemImageBox.GetComponent<Image>().sprite = _itemImage;
    }
    public void DisplayItemDescription()
    {
        if (ComponentHasImage())
        {
            _itemDescriptionBox.text = _itemDescription;
            _itemNameBox.text = _itemName;

            _characterAudioManager.PlaySound(_characterAudioManager.AudioClips[2], false, .6f, 1);
        }
    }
    
    bool ComponentHasImage()
    {
        return _itemImageBox.GetComponent<Image>();
    }
}

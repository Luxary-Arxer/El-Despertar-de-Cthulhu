
using TMPro;
using UnityEngine;

public class HintSlotManager : MonoBehaviour
{
    CharacterAudioManager _characterAudioManager;

    [Header("UI elements")]
    [SerializeField]
    TextMeshProUGUI _hintDescriptionBox;
    [SerializeField]
    TextMeshProUGUI _hintNameBox;
    [SerializeField]
    TextMeshProUGUI _hintTextBox;

    string _hintName;
    string _hintDescription;

    public string HintName { set { _hintName = value; } }
    public string HintDescription { set { _hintDescription = value; } }


    void Awake()
    {
        _characterAudioManager = FindFirstObjectByType<CharacterAudioManager>();
    }
    public void DisplayTextOnInventory()
    {
        _hintTextBox.text = _hintName;
    }
    public void DisplayHintDescription()
    {
        if (_hintName != null)
        {
            _hintDescriptionBox.text = _hintDescription;
            _hintNameBox.text = _hintName;

            _characterAudioManager.PlaySound(_characterAudioManager.AudioClips[2], false, .6f, 1);
        }
    }
}

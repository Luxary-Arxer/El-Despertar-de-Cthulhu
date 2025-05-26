
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HintSlotManager : MonoBehaviour
{
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

    CharacterAudioManager _characterAudioManager;

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
        if (ComponentHasHint())
        {
            _hintDescriptionBox.text = _hintDescription;
            _hintNameBox.text = _hintName;

            _characterAudioManager.PlaySound(_characterAudioManager.AudioClips[2], false, .6f, 1);
        }
    }
    
    bool ComponentHasHint()
    {
        return _hintName != null;
    }
}

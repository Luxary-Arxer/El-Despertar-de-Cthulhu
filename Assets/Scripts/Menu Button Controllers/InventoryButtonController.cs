
using UnityEngine;

public class InventoryButtonController : MonoBehaviour
{
    [SerializeField]
    GameObject _hintsInventory;
    [SerializeField]
    GameObject _itemsInventory;
    [SerializeField]
    GameObject _logsInventory;

    CharacterAudioManager _characterAudioManager;

    void Awake()
    {
        _characterAudioManager = FindFirstObjectByType<CharacterAudioManager>();
    }
    public void SwitchToHintsInventory()
    {
        _hintsInventory.SetActive(true);

        _itemsInventory.SetActive(false);
        _logsInventory.SetActive(false);

        _characterAudioManager.PlaySound(_characterAudioManager.AudioClips[2], false, .6f, 1);
    }
    public void SwitchToItemInventory()
    {
        _itemsInventory.SetActive(true);

        _hintsInventory.SetActive(false);
        _logsInventory.SetActive(false);

        _characterAudioManager.PlaySound(_characterAudioManager.AudioClips[2], false, .6f, 1);
    }
    public void SwitchToLogsInventory()
    {
        _logsInventory.SetActive(true);

        _hintsInventory.SetActive(false);
        _itemsInventory.SetActive(false);

        _characterAudioManager.PlaySound(_characterAudioManager.AudioClips[2], false, .6f, 1);
    }
}

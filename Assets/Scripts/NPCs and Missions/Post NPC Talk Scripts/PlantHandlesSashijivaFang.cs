using System.Collections;
using DialogueEditor;
using UnityEngine;

public class PlantHandlesSashijivaFang : MonoBehaviour
{
    PlayerInputController _playerInputController;
    CharacterAudioManager _characterAudioManager;

    void Awake()
    {
        _playerInputController = FindFirstObjectByType<PlayerInputController>();
        _characterAudioManager = FindFirstObjectByType<CharacterAudioManager>();
    }
    void OnEnable()
    {
        ConversationManager.OnConversationEnded += PlantHandlesItem;
    }
    void OnDisable()
    {
        ConversationManager.OnConversationEnded -= PlantHandlesItem;
    }
    void PlantHandlesItem()
    {
        if (QuestManager.ReachedFinalNodePlantConversation)
        {
            StartCoroutine(WaitThenHandleItem());
        }
    }
    IEnumerator WaitThenHandleItem()
    {
        yield return new WaitForSeconds(.65f);

        _playerInputController.OpenInventoryNotByInputAction();

        _characterAudioManager.PlaySound(_characterAudioManager.AudioClips[0], false, .75f, 1);

        _playerInputController.HintsInventory.SetActive(false);
        _playerInputController.ItemsInventory.SetActive(true);
        _playerInputController.LogsInventory.SetActive(false);

        QuestManager.ReachedFinalNodePlantConversation = false;
    }
}

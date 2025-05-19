
using UnityEngine;
using DialogueEditor;
using System.Collections;

public class JanitorHandlesBifiaKey : MonoBehaviour
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
        ConversationManager.OnConversationEnded += JanitorHandlesItem;
    }
    void OnDisable()
    {
        ConversationManager.OnConversationEnded -= JanitorHandlesItem;
    }
    void JanitorHandlesItem()
    {
        if (QuestManager.ReachedFinalNodeJanitorConversation)
        {
            StartCoroutine(WaitThenHandleItem());
        }
    }
    IEnumerator WaitThenHandleItem()
    {
        yield return new WaitForSeconds(.3f);

        _playerInputController.OpenInventoryNotByInputAction();

        _characterAudioManager.PlaySound(_characterAudioManager.AudioClips[0], false, .75f, 1);

        _playerInputController.HintsInventory.SetActive(false);
        _playerInputController.ItemsInventory.SetActive(true);
        _playerInputController.LogsInventory.SetActive(false);

        QuestManager.ReachedFinalNodeJanitorConversation = false;
    }
}

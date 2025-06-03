
using System.Collections;
using DialogueEditor;
using UnityEngine;

public class PlantHandlesEphrieLog : MonoBehaviour
{
    [SerializeField]
    GameObject _viktraLogic;
    PlayerInputController _playerInputController;
    CharacterAudioManager _characterAudioManager;

    void Awake()
    {
        _playerInputController = _viktraLogic.GetComponent<PlayerInputController>();
        _characterAudioManager = _viktraLogic.GetComponent<CharacterAudioManager>();
    }
    void OnEnable()
    {
        ConversationManager.OnConversationEnded += PlantHandlesLog;
    }
    void OnDisable()
    {
        ConversationManager.OnConversationEnded -= PlantHandlesLog;
    }
    void PlantHandlesLog()
    {
        if (QuestManager.ReachedFinalNodeLogPlantConversation)
        {
            StartCoroutine(WaitThenHandleLog());
        }
    }
    IEnumerator WaitThenHandleLog()
    {
        yield return new WaitForSeconds(.65f);

        _playerInputController.OpenInventoryNotByInputAction();

        _characterAudioManager.PlaySound(_characterAudioManager.AudioClips[0], false, .75f, 1);

        _playerInputController.HintsInventory.SetActive(false);
        _playerInputController.ItemsInventory.SetActive(false);
        _playerInputController.LogsInventory.SetActive(true);

        QuestManager.ReachedFinalNodeLogPlantConversation = false;
    }
}

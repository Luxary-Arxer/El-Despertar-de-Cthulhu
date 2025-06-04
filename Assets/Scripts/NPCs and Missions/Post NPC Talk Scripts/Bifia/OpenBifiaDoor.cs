using System.Collections;
using DialogueEditor;
using UnityEngine;

public class OpenBifiaDoor : MonoBehaviour
{
    [SerializeField]
    FadeManager _fadeManager;
    [SerializeField]
    GameObject _openedDoorObject;
    CharacterAudioManager _characterAudioManager;
    void Awake()
    {
        _characterAudioManager = FindFirstObjectByType<CharacterAudioManager>();
    }
    void OnEnable()
    {
        ConversationManager.OnConversationEnded += OpenBifiaRoomDoor;
    }
    void OnDisable()
    {
        ConversationManager.OnConversationEnded -= OpenBifiaRoomDoor;
    }
    void OpenBifiaRoomDoor()
    {
        if (QuestManager.ReachedFinalNodeBifiaDoorConversation)
        {
            _fadeManager.gameObject.SetActive(true);
            StartCoroutine(WaitThenOpenDoor());
        }
    }
    IEnumerator WaitThenOpenDoor()
    {
        yield return new WaitForSeconds(1.5f);
        _characterAudioManager.PlaySound(_characterAudioManager.AudioClips[5], false, .75f, 1);
        QuestManager.ReachedFinalNodeBifiaDoorConversation = false;
        _openedDoorObject.SetActive(true);
        gameObject.SetActive(false);
    }
}

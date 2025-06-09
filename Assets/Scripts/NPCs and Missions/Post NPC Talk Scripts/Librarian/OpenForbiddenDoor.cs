using System.Collections;
using DialogueEditor;
using UnityEngine;

public class OpenForbiddenDoor : MonoBehaviour
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
        ConversationManager.OnConversationEnded += OpenForbiddenRoomDoor;
    }
    void OnDisable()
    {
        ConversationManager.OnConversationEnded -= OpenForbiddenRoomDoor;
    }
    void OpenForbiddenRoomDoor()
    {
        if (QuestManager.ReachedFinalNodeLibrarianConverastion)
        {
            _fadeManager.gameObject.SetActive(true);
            StartCoroutine(WaitThenOpenDoor());
        }
    }
    IEnumerator WaitThenOpenDoor()
    {
        yield return new WaitForSeconds(1.5f);
        _characterAudioManager.PlaySound(_characterAudioManager.AudioClips[5], false, 1, 1);
        QuestManager.ReachedFinalNodeLibrarianConverastion = false;
        _openedDoorObject.SetActive(true);
    }
}

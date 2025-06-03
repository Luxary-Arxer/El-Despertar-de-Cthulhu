using System.Collections;
using DialogueEditor;
using UnityEngine;

public class OpenForbiddenDoor : MonoBehaviour
{
    [SerializeField]
    FadeManager _fadeManager;
    [SerializeField]
    GameObject _openedDoorObject;
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
        QuestManager.ReachedFinalNodeLibrarianConverastion = false;
        _openedDoorObject.SetActive(true);
        gameObject.SetActive(false);
    }
}

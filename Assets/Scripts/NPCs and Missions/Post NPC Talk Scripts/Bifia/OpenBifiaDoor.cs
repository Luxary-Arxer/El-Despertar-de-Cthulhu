using System.Collections;
using DialogueEditor;
using UnityEngine;

public class OpenBifiaDoor : MonoBehaviour
{
    [SerializeField]
    FadeManager _fadeManager;
    [SerializeField]
    GameObject _doorObject;
    void OnEnable()
    {
        ConversationManager.OnConversationEnded += OpenDoor;
    }
    void OnDisable()
    {
        ConversationManager.OnConversationEnded -= OpenDoor;
    }
    void OpenDoor()
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
        _doorObject.transform.rotation = Quaternion.Euler(0, 330, 0);
        QuestManager.ReachedFinalNodeBifiaDoorConversation = false;
    }
}

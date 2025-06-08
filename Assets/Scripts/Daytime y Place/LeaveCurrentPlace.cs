
using UnityEngine;
using DialogueEditor;
using System.Collections;

public class LeaveCurrentPlace : MonoBehaviour
{
    [SerializeField]
    GameObject _interactCanvas;
    [SerializeField]
    NPCConversation _defeatConversation;

    void OnEnable()
    {
        ConversationManager.OnConversationEnded += LeavePlace;
    }
    void OnDisable()
    {
        ConversationManager.OnConversationEnded -= LeavePlace;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _interactCanvas.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _interactCanvas.SetActive(false);
        }
    }
    public void LeavePlace()
    {
        if (QuestManager.ReachedFinalNodeLeaveConversation)
        {
            StartCoroutine(WaitThenLeaveCurrentPlace());
            QuestManager.ReachedFinalNodeLeaveConversation = false;
        }
    }
    IEnumerator WaitThenLeaveCurrentPlace()
    {
        yield return new WaitForSeconds(.5f);
        if (DaytimeTracker.MomentOfTheDay < 2)
        {
            DaytimeTracker.AdvanceThroughTheDay();
        }
        else
        {
            ConversationManager.Instance.StartConversation(_defeatConversation);
        }
    }
}

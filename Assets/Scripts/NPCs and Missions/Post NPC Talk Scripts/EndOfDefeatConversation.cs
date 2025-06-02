
using UnityEngine;
using DialogueEditor;

public class EndOfDefeatConversation : MonoBehaviour
{
    void OnEnable()
    {
        ConversationManager.OnConversationEnded += EndOfDefeatSequence;
    }
    void OnDisable()
    {
        ConversationManager.OnConversationEnded -= EndOfDefeatSequence;
    }

    void EndOfDefeatSequence()
    {
        if (QuestManager.ReachedFinalNodeDefeatConversation)
        {
            QuestManager.ReachedFinalNodeDefeatConversation = false;
            DaytimeTracker.RestartDay();
        }
    }
}


using DialogueEditor;
using UnityEngine;

public class EndOfVictoryConversation : MonoBehaviour
{
    void OnEnable()
    {
        ConversationManager.OnConversationEnded += EndOfVictorySequence;
    }
    void OnDisable()
    {
        ConversationManager.OnConversationEnded -= EndOfVictorySequence;
    }

    void EndOfVictorySequence()
    {
        if (QuestManager.ReachedFinalNodeVictoryConversation)
        {
            QuestManager.ReachedFinalNodeVictoryConversation = false;
            DaytimeTracker.RestartGame();
        }
    }    
}


using DialogueEditor;
using UnityEngine;

public class EndOfPostEphrieDeath : MonoBehaviour
{
    void OnEnable()
    {
        ConversationManager.OnConversationEnded += EndOfEphrieDeathSequence;
    }
    void OnDisable()
    {
        ConversationManager.OnConversationEnded -= EndOfEphrieDeathSequence;
    }

    void EndOfEphrieDeathSequence()
    {
        if (QuestManager.ReachedFinalNodeEphrieDeathConversation)
        {
            QuestManager.ReachedFinalNodeEphrieDeathConversation = false;
            GetComponent<CheckVictory>().CheckVictoryByDeath();
        }
    }
}

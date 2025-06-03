
using DialogueEditor;
using UnityEngine;

public class EndOfPostEurialeDeath : MonoBehaviour
{
    void OnEnable()
    {
        ConversationManager.OnConversationEnded += EndOfEurialeDeathSequence;
    }
    void OnDisable()
    {
        ConversationManager.OnConversationEnded -= EndOfEurialeDeathSequence;
    }

    void EndOfEurialeDeathSequence()
    {
        if (QuestManager.ReachedFinalNodeEurialeDeathConversation)
        {
            QuestManager.ReachedFinalNodeEurialeDeathConversation = false;
            GetComponent<CheckVictory>().CheckVictoryByDeath();
        }
    }
}

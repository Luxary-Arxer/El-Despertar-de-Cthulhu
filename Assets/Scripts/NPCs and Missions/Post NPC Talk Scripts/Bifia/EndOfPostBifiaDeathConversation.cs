
using UnityEngine;
using DialogueEditor;

public class EndOfPostBifiaDeathConversation : MonoBehaviour
{
    void OnEnable()
    {
        ConversationManager.OnConversationEnded += EndOfBifiaDeathSequence;
    }
    void OnDisable()
    {
        ConversationManager.OnConversationEnded -= EndOfBifiaDeathSequence;
    }

    void EndOfBifiaDeathSequence()
    {
        if (QuestManager.ReachedFinalNodePostBifiaDeathConversation)
        {
            QuestManager.ReachedFinalNodePostBifiaDeathConversation = false;
            GetComponent<CheckVictory>().CheckVictoryByDeath();
        }
    }
}

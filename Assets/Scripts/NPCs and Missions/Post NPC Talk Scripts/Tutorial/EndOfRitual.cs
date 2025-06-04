
using DialogueEditor;
using UnityEngine;

public class EndOfRitual : MonoBehaviour
{
    [SerializeField]
    NPCConversation _defeatConversation;
    void OnEnable()
    {
        ConversationManager.OnConversationEnded += EndOfRitualConversation;
    }
    void OnDisable()
    {
        ConversationManager.OnConversationEnded -= EndOfRitualConversation;
    }
    void EndOfRitualConversation()
    {
        if (QuestManager.ReachedFinalNodeRitualConversation)
        {
            QuestManager.ReachedFinalNodeRitualConversation = false;
            ConversationManager.Instance.StartConversation(_defeatConversation);
        }
    }
}

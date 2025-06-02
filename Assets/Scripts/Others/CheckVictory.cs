
using DialogueEditor;
using UnityEngine;

public class CheckVictory : MonoBehaviour
{
    [SerializeField]
    NPCConversation _victoryConversation;

    public void CheckVictoryByDeath()
    {
        if (QuestManager.IsBifiaDead && QuestManager.IsEphrieDead && QuestManager.IsEurialeDead && QuestManager.IsKorbyDead)
            ConversationManager.Instance.StartConversation(_victoryConversation);
    }
}

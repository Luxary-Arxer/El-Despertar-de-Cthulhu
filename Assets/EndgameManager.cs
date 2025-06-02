
using DialogueEditor;
using UnityEngine;

public class EndgameManager : MonoBehaviour
{
    [SerializeField]
    NPCConversation _victoryConversation;
    [SerializeField]
    NPCConversation _defeatConversation;

    public void LoadEndGameScene()
    {
        if (QuestManager.IsKorbyDead && QuestManager.IsBifiaDead && QuestManager.IsEurialeDead && QuestManager.IsEphrieDead)
        {
            ConversationManager.Instance.StartConversation(_victoryConversation);
        }
        else
        {
            ConversationManager.Instance.StartConversation(_defeatConversation);
        }
    }
}

using System.Collections;
using UnityEngine;
using DialogueEditor;


public class ChefLeavesArea : MonoBehaviour
{
    [SerializeField]
    FadeManager _fadeManager;
    void OnEnable()
    {
        ConversationManager.OnConversationEnded += ChefLeaves;
    }
    void OnDisable()
    {
        ConversationManager.OnConversationEnded -= ChefLeaves;
    }
    void ChefLeaves()
    {
        if (QuestManager.HasRatsInfo && QuestManager.ReachedFinalNodeChefConversation)
        {
            _fadeManager.gameObject.SetActive(true);
            StartCoroutine(WaitForFade());
        }
    }
    IEnumerator WaitForFade()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
        QuestManager.ReachedFinalNodeChefConversation = false;
    }    
}

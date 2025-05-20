using System.Collections;
using UnityEngine;
using DialogueEditor;

public class KorbyDeath : MonoBehaviour
{
    [SerializeField]
    FadeManager _fadeManager;
    [SerializeField]
    NPCConversation _korbyDeathConversation;
    void OnEnable()
    {
        ConversationManager.OnConversationEnded += KorbyDeathSequence;
    }
    void OnDisable()
    {
        ConversationManager.OnConversationEnded -= KorbyDeathSequence;
    }
    void KorbyDeathSequence()
    {
        if (QuestManager.ReachedFinalNodeDishConversation)
        {
            _fadeManager.gameObject.SetActive(true);
            StartCoroutine(WaitForFade());
        }
    }
    IEnumerator WaitForFade()
    {
        yield return new WaitForSeconds(6f);
        ConversationManager.Instance.StartConversation(_korbyDeathConversation);
        QuestManager.IsKorbyDead = true;
        QuestManager.ReachedFinalNodeDishConversation = false;
    }
}

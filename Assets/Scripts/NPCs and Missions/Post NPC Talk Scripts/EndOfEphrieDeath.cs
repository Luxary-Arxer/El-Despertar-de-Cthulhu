using System.Collections;
using System.Collections.Generic;
using DialogueEditor;
using UnityEngine;

public class EndOfEphrieDeath : MonoBehaviour
{
    [SerializeField]
    FadeManager _fadeManager;
    [SerializeField]
    NPCConversation _postEphrieDeathConversation;

    void OnEnable()
    {
        ConversationManager.OnConversationEnded += EphrieDeathSequenceEnd;
    }
    void OnDisable()
    {
        ConversationManager.OnConversationEnded -= EphrieDeathSequenceEnd;
    }
    void EphrieDeathSequenceEnd()
    {
        if (QuestManager.ReachedFinalNodeEphrieConversation)
        {
            _fadeManager.gameObject.SetActive(true);
            StartCoroutine(WaitForFade());
        }
    }
    IEnumerator WaitForFade()
    {
        yield return new WaitForSeconds(1.5f);
        QuestManager.ReachedFinalNodeEphrieConversation = false;
        QuestManager.IsEphrieDead = true;
        ConversationManager.Instance.StartConversation(_postEphrieDeathConversation);
        gameObject.SetActive(false);
    
    }
}

using System.Collections;
using UnityEngine;
using DialogueEditor;

public class LadyBifiaDeath : MonoBehaviour
{
    [SerializeField]
    FadeManager _fadeManager;
    [SerializeField]
    NPCConversation _postBifiaDeathConversation;
    void OnEnable()
    {
        ConversationManager.OnConversationEnded += BifiaDeath;
    }
    void OnDisable()
    {
        ConversationManager.OnConversationEnded -= BifiaDeath;
    }
    void BifiaDeath()
    {
        if (QuestManager.ReachedFinalNodeBifiaConversation)
        {
            _fadeManager.gameObject.SetActive(true);
            StartCoroutine(WaitForFade());
        }
    }
    IEnumerator WaitForFade()
    {
        yield return new WaitForSeconds(1.5f);
        //Mover a Viktra fuera de la habitación y bloquear la puerta de entrada
        ConversationManager.Instance.StartConversation(_postBifiaDeathConversation);
        QuestManager.IsBifiaDead = true;
        QuestManager.ReachedFinalNodeBifiaConversation = false;
    }    
}

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
    CharacterAudioManager _characterAudioManager;

    void Awake()
    {
        _characterAudioManager = FindFirstObjectByType<CharacterAudioManager>();
    }
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
        _characterAudioManager.PlaySound(_characterAudioManager.AudioClips[4], false, .75f, 1);
        QuestManager.ReachedFinalNodeEphrieConversation = false;
        QuestManager.IsEphrieDead = true;
        ConversationManager.Instance.StartConversation(_postEphrieDeathConversation);
        gameObject.SetActive(false);
    }
}

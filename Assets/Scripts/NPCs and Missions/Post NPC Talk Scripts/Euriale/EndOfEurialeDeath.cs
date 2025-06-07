using System.Collections;
using DialogueEditor;
using UnityEngine;

public class EndOfEurialeDeath : MonoBehaviour
{
    [SerializeField]
    FadeManager _fadeManager;
    [SerializeField]
    NPCConversation _postEurialeDeathConversation;
    CharacterAudioManager _characterAudioManager;
    void Awake()
    {
        _characterAudioManager = FindFirstObjectByType<CharacterAudioManager>();
    }
    void OnEnable()
    {
        ConversationManager.OnConversationEnded += EurialeDeathSequenceEnd;
    }
    void OnDisable()
    {
        ConversationManager.OnConversationEnded -= EurialeDeathSequenceEnd;
    }
    void EurialeDeathSequenceEnd()
    {
        if (QuestManager.ReachedFinalNodeEurialeConversation)
        {
            _fadeManager.gameObject.SetActive(true);
            StartCoroutine(WaitForFade());
        }
    }
    IEnumerator WaitForFade()
    {
        yield return new WaitForSeconds(1.5f);
        _characterAudioManager.PlaySound(_characterAudioManager.AudioClips[4], false, 1, 1);
        QuestManager.ReachedFinalNodeEurialeConversation = false;
        QuestManager.IsEurialeDead = true;
        ConversationManager.Instance.StartConversation(_postEurialeDeathConversation);
        gameObject.SetActive(false);

    }
}

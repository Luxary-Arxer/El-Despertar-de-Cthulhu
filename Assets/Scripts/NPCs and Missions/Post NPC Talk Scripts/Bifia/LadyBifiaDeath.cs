using System.Collections;
using UnityEngine;
using DialogueEditor;

public class LadyBifiaDeath : MonoBehaviour
{
    CharacterAudioManager _characterAudioManager;

    [SerializeField]
    FadeManager _fadeManager;
    [SerializeField]
    NPCConversation _postBifiaDeathConversation;

    void Awake()
    {
        _characterAudioManager = FindFirstObjectByType<CharacterAudioManager>();
    }
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
        _characterAudioManager.PlaySound(_characterAudioManager.AudioClips[4], false, 1, 1);
        QuestManager.IsBifiaDead = true;
        QuestManager.ReachedFinalNodeBifiaConversation = false;
        ConversationManager.Instance.StartConversation(_postBifiaDeathConversation);

        gameObject.SetActive(false);
    }
}

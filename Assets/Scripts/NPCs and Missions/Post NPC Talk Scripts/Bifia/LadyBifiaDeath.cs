using System.Collections;
using UnityEngine;
using DialogueEditor;

public class LadyBifiaDeath : MonoBehaviour
{
    CharacterAudioManager _characterAudioManager;

    [SerializeField]
    Transform _viktraLogic;
    [SerializeField]
    Transform _viktraSprite;
    [SerializeField]
    Transform _cameraPivot;
    [SerializeField]
    Transform _endOfSequencePosition;
    [SerializeField]
    FadeManager _fadeManager;
    [SerializeField]
    NPCConversation _postBifiaDeathConversation;
    [SerializeField]
    GameObject _bifiaRoom;
    [SerializeField]
    GameObject _corridor;


    void Awake()
    {
        _characterAudioManager = _viktraLogic.gameObject.GetComponent<CharacterAudioManager>();
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
        _viktraLogic.position = _endOfSequencePosition.position;
        _viktraSprite.position = new(_endOfSequencePosition.position.x - .8f, _endOfSequencePosition.position.y - 1.5f, _endOfSequencePosition.position.z - .8f);
        _cameraPivot.position = _endOfSequencePosition.position;
        _bifiaRoom.SetActive(false);
        _corridor.SetActive(true);
        QuestManager.IsBifiaDead = true;
        QuestManager.ReachedFinalNodeBifiaConversation = false;
        ConversationManager.Instance.StartConversation(_postBifiaDeathConversation);

        gameObject.SetActive(false);
    }
}

using System.Collections;
using UnityEngine;
using DialogueEditor;

public class LadyBifiaDeath : MonoBehaviour
{
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
    [SerializeField]
    GameObject _postDeathBifiaDoor;
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
        _viktraLogic.position = _endOfSequencePosition.position;
        _viktraSprite.position = _endOfSequencePosition.position;
        _cameraPivot.position = _endOfSequencePosition.position;
        _bifiaRoom.SetActive(false);
        _corridor.SetActive(true);
        _postDeathBifiaDoor.SetActive(true);
        QuestManager.IsBifiaDead = true;
        QuestManager.ReachedFinalNodeBifiaConversation = false;
        QuestManager.IsBifiaDoorOpened = false;
        ConversationManager.Instance.StartConversation(_postBifiaDeathConversation);
    }
}

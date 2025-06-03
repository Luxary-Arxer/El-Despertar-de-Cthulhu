
using UnityEngine;
using DialogueEditor;
using System.Collections;

public class EndOfKorbyDeath : MonoBehaviour
{
    [SerializeField]
    FadeManager _fadeManager;
    [SerializeField]
    Transform _cameraPivot;
    [SerializeField]
    GameObject _korby;
    [SerializeField]
    GameObject _viktraPosition;

    void OnEnable()
    {
        ConversationManager.OnConversationEnded += KorbyDeathSequenceEnd;
    }
    void OnDisable()
    {
        ConversationManager.OnConversationEnded -= KorbyDeathSequenceEnd;
    }
    void KorbyDeathSequenceEnd()
    {
        if (QuestManager.ReachedFinalNodeKorbyDeathConversation)
        {
            _fadeManager.gameObject.SetActive(true);
            StartCoroutine(WaitForFade());
        }
    }
    IEnumerator WaitForFade()
    {
        yield return new WaitForSeconds(1.5f);
        QuestManager.ReachedFinalNodeKorbyDeathConversation = false;
        _korby.SetActive(false);
        _cameraPivot.position = _viktraPosition.transform.position;
        _viktraPosition.GetComponent<PlayerInputController>().EnablePlayerControlls();
        GetComponent<CheckVictory>().CheckVictoryByDeath();
    }
}

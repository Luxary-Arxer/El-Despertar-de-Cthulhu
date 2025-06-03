
using System.Collections;
using DialogueEditor;
using UnityEngine;

public class LaboratoryGuardianMoves : MonoBehaviour
{
    [SerializeField]
    FadeManager _fadeManager;
    [SerializeField]
    Transform _finalPosition;
    [SerializeField]
    GameObject _guardianCollider;
    void OnEnable()
    {
        ConversationManager.OnConversationEnded += GuardianMovesAway;
    }
    void OnDisable()
    {
        ConversationManager.OnConversationEnded -= GuardianMovesAway;
    }
    void GuardianMovesAway()
    {
        if (QuestManager.ReachedFinalNodeGuardianConversation)
        {
            _fadeManager.gameObject.SetActive(true);
            StartCoroutine(WaitThenOpenDoor());
        }
    }
    IEnumerator WaitThenOpenDoor()
    {
        yield return new WaitForSeconds(1.5f);
        QuestManager.ReachedFinalNodeGuardianConversation = false;
        transform.position = _finalPosition.position;
        _guardianCollider.SetActive(false);
    }
}

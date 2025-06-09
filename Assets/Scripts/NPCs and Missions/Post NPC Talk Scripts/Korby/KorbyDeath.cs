using System.Collections;
using UnityEngine;
using DialogueEditor;

public class KorbyDeath : MonoBehaviour
{
    [SerializeField]
    FadeManager _fadeManager;
    [SerializeField]
    NPCConversation _korbyDeathConversation;
    [SerializeField]
    Transform _viktraPosition;
    [SerializeField]
    Transform _cameraPosition;
    [SerializeField]
    Transform _viktraLogic;
    [SerializeField]
    Transform _viktraSprite;
    [SerializeField]
    Transform _cameraPivot;
    [SerializeField]
    GameObject _dishGameObject;
    [SerializeField]
    GameObject _waiterGameObject;
    [SerializeField]
    GameObject _diningRoom;
    [SerializeField]
    GameObject _kitchen;

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
        yield return new WaitForSeconds(1.5f);
        _waiterGameObject.SetActive(true);
        _dishGameObject.SetActive(true);
        _diningRoom.SetActive(true);
        _cameraPivot.position = _cameraPosition.position;
        _viktraLogic.position = _viktraPosition.position;
        _viktraSprite.position = new(_viktraPosition.position.x - .8f, _viktraPosition.position.y - 1.5f, _viktraPosition.position.z - .8f);
        yield return new WaitForSeconds(3);
        ConversationManager.Instance.StartConversation(_korbyDeathConversation);
        QuestManager.IsKorbyDead = true;
        QuestManager.ReachedFinalNodeDishConversation = false;
        gameObject.SetActive(false);
        _kitchen.SetActive(false);
    }
}

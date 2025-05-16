
using UnityEngine;
using DialogueEditor;
using TMPro;

public class TalkToNPC : MonoBehaviour
{
    [SerializeField]
    GameObject _interactCanvas;
    [SerializeField]
    string _NPCName;

    NPCConversation _currentConversation;

    void OnEnable()
    {
        ConversationManager.OnConversationStarted += ConversationStarted;
        ConversationManager.OnConversationEnded += ConversationEnded;
    }
    void OnDisable()
    {
        ConversationManager.OnConversationStarted -= ConversationStarted;
        ConversationManager.OnConversationEnded -= ConversationEnded;
    }
    void Awake()
    {
        _currentConversation = GetComponent<NPCConversation>();
        GetComponentInChildren<TextMeshProUGUI>().text = _NPCName;
        _interactCanvas.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _interactCanvas.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _interactCanvas.SetActive(false);
            ConversationManager.Instance.EndConversation();
        }
    }

    public void StartTalkToNPC()
    {
        ConversationManager.Instance.StartConversation(_currentConversation);
    }
    void ConversationStarted()
    {
        Cursor.visible = true;
    }
    void ConversationEnded()
    {
        Cursor.visible = false;
    }
}

using UnityEngine;
using DialogueEditor;
using TMPro;

public class TalkToNPC : MonoBehaviour
{
    [SerializeField]
    string _NPCName;
    [SerializeField]
    Sprite _NPCSprite;
    GameObject _interactCanvas;

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
        GetComponentInChildren<TextMeshProUGUI>().text = _NPCName;
        GetComponentInChildren<SpriteRenderer>().sprite = _NPCSprite;

        _currentConversation = GetComponent<NPCConversation>();
        _interactCanvas = GetComponentInChildren<Canvas>().gameObject;
        
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
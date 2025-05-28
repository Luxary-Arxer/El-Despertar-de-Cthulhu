
using UnityEngine;
using DialogueEditor;
using TMPro;

public class IntNPCManager : MonoBehaviour
{
    [SerializeField]
    string _NPCName;
    [SerializeField]
    Sprite _NPCSprite;
    GameObject _interactCanvas;
    
    void Awake()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = _NPCName;
        GetComponentInChildren<SpriteRenderer>().sprite = _NPCSprite;

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
}
using System.Collections;
using System.Collections.Generic;
using DialogueEditor;
using UnityEngine;

public class StartTalkToNPC : MonoBehaviour
{
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
    }
    public void BeginConversation()
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

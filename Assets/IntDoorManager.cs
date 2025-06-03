
using DialogueEditor;
using UnityEngine;

public class IntDoorManager : MonoBehaviour
{
void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ConversationManager.Instance.EndConversation();
        }
    }
}

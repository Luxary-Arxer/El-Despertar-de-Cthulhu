
using DialogueEditor;
using UnityEngine;

public class TriggerRitualStart : MonoBehaviour
{
    [SerializeField]
    NPCConversation _ritualStartConversation;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerInputController>().PlayerControlls.Player.Disable();
            ConversationManager.Instance.StartConversation(_ritualStartConversation);
            Cursor.visible = true;
        }
    }
}

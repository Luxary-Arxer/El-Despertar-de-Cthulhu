
using DialogueEditor;
using UnityEngine;

public class StopSoundOnConversationEnd : MonoBehaviour
{
    void OnEnable()
    {
        ConversationManager.OnConversationEnded += StopSounds;
    }
    void OnDisable()
    {
        ConversationManager.OnConversationEnded += StopSounds;
    }
    void StopSounds() {
        GetComponent<AudioSource>().Stop();
    }
}

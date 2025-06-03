
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
        ConversationManager.OnConversationEnded -= StopSounds;
    }
    void StopSounds()
    {
        if (ConversationManager.Instance.IsConversationActive)
            GetComponent<AudioSource>().Stop();
    }
}

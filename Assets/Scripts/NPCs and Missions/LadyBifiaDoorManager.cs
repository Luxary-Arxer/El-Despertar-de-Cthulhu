
using DialogueEditor;
using UnityEngine;

public class LadyBifiaDoorManager : MonoBehaviour
{
    [SerializeField]
    GameObject _doorVFX;

    void Awake()
    {
        _doorVFX.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !QuestManager.IsBifiaDoorOpened)
        {
            _doorVFX.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !QuestManager.IsBifiaDoorOpened)
        {
            _doorVFX.SetActive(false);
            ConversationManager.Instance.EndConversation();
        }
    }
}

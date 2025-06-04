
using DialogueEditor;
using UnityEngine;

public class PlayConversationOnAwake : MonoBehaviour
{
    [SerializeField]
    GameObject _tutorialImage;
    void Start()
    {
        ConversationManager.Instance.StartConversation(GetComponent<NPCConversation>());
    }
    void OnEnable()
    {
        ConversationManager.OnConversationEnded += ToggleTutorialImage;
    }
    void OnDisable()
    {
        ConversationManager.OnConversationEnded -= ToggleTutorialImage;
    }
    void ToggleTutorialImage()
    {
        if (_tutorialImage)
        {
            _tutorialImage.SetActive(false);
        }
    }
}

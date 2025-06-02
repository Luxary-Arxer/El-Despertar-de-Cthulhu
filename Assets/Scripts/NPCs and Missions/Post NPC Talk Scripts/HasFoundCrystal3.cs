
using DialogueEditor;
using UnityEngine;

public class HasFoundCrystal3 : MonoBehaviour
{
[SerializeField]
    GameObject _falseCrystal;
    void OnEnable()
    {
        ConversationManager.OnConversationEnded += FoundCrystal;
    }
    void OnDisable()
    {
        ConversationManager.OnConversationEnded -= FoundCrystal;
    }
    void FoundCrystal()
    {
        if (QuestManager.FoundThirdCrystal)
        {
            _falseCrystal.SetActive(true);
            gameObject.SetActive(false);
            QuestManager.FoundThirdCrystal = false;
        }
    }
}

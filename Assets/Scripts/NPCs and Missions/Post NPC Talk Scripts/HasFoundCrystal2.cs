
using DialogueEditor;
using UnityEngine;

public class HasFoundCrystal2 : MonoBehaviour
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
        if (QuestManager.FoundSecondCrystal)
        {
            _falseCrystal.SetActive(true);
            gameObject.SetActive(false);
            QuestManager.FoundSecondCrystal = false;
        }
    }
}

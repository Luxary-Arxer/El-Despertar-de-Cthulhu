
using System.Collections;
using DialogueEditor;
using UnityEngine;

public class GuideMovesAway : MonoBehaviour
{
    [SerializeField]
    FadeManager _fadeManager;
    void OnEnable()
    {
        ConversationManager.OnConversationEnded += GuideLeaves;
    }
    void OnDisable()
    {
        ConversationManager.OnConversationEnded -= GuideLeaves;
    }
    void GuideLeaves()
    {
        if (QuestManager.ReachedFinalNodeGuideConversation)
        {
            _fadeManager.gameObject.SetActive(true);
            StartCoroutine(WaitForFade());
        }
    }
    IEnumerator WaitForFade()
    {
        yield return new WaitForSeconds(1.5f);
        QuestManager.ReachedFinalNodeGuideConversation = false;
        gameObject.SetActive(false);
    }
}


using UnityEngine;

public class CheckEphrieCurrentlyDead : MonoBehaviour
{
    void OnEnable()
    {
        if (QuestManager.IsEphrieDead)
            gameObject.SetActive(false);
    }
}

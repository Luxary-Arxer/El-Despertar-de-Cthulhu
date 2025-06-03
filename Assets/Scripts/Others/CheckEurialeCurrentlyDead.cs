
using UnityEngine;

public class CheckEurialeCurrentlyDead : MonoBehaviour
{
    void OnEnable()
    {
        if (QuestManager.IsEurialeDead)
            gameObject.SetActive(false);
    }
}

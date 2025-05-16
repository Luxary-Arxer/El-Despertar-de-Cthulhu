using System.Collections;
using TMPro;
using UnityEngine;

public class GenericNPCManager : MonoBehaviour
{
    [TextArea(5,5)]
    [SerializeField]
    string _NPCText;
    TextMeshProUGUI _textComponent;
    void Awake()
    {
        _textComponent = GetComponentInChildren<TextMeshProUGUI>();
        _textComponent.text = _NPCText;
        StartCoroutine(ShowTextRoutine());
    }
    IEnumerator ShowTextRoutine(){
        _textComponent.gameObject.SetActive(true);
        yield return new WaitForSeconds(10);
        StartCoroutine(HideTextRoutine());
    }

    IEnumerator HideTextRoutine(){
        _textComponent.gameObject.SetActive(false);
        yield return new WaitForSeconds(10);
        StartCoroutine(ShowTextRoutine());
    }
}

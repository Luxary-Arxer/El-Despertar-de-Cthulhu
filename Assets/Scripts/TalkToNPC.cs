
using UnityEngine;

public class TalkToNPC : MonoBehaviour
{
    [SerializeField]
    GameObject _interactCanvas;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _interactCanvas.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _interactCanvas.SetActive(false);
        }
    }
    public void StartTalkToNPC()
    {
        Debug.Log("Talking to NPC!");
    }
}

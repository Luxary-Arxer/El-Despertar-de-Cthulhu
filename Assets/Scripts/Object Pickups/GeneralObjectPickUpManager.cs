
using UnityEngine;

public class GeneralObjectPickUpManager : MonoBehaviour
{
    [SerializeField]
    GameObject _interactCanvas;

    public void OnObjectPicked()
    {
        Destroy(gameObject);
    }
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
}

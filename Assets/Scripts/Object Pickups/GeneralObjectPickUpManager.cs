
using TMPro;
using UnityEngine;

public class GeneralObjectPickUpManager : MonoBehaviour
{
    [SerializeField]
    GameObject _interactCanvas;
    [SerializeField]
    string _objectName;

    void Awake()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = _objectName;
        _interactCanvas.SetActive(false);
    }
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

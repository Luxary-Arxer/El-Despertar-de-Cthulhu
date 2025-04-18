
using UnityEngine;

public class ItemPickUp : MonoBehaviour
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
    public void PickUpItem()
    {
        Debug.Log("Picked Up Item!");
    }
}

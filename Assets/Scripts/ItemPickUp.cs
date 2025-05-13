
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField]
    GameObject _interactCanvas;

    [SerializeField]
    ItemObject _item;
    public ItemObject Item { get { return _item; } }

    public void OnItemPicked()
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


using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField]
    GameObject _interactCanvas;

    [Header("Item elements")]
    [SerializeField]
    string _name;
    [SerializeField]
    string _description;
    Sprite _image;
    public Sprite Image { get { return _image; } }
    public string Name { get { return _name; } }
    public string Description { get { return _description; } }

    void Awake()
    {
        _image = GetComponentInChildren<SpriteRenderer>().sprite;
    }
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

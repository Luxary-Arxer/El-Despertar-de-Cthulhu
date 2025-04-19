
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField]
    GameObject _interactCanvas;
    [SerializeField]
    string _name;
    [SerializeField]
    string _description;
    SpriteRenderer _image;
    public SpriteRenderer Image { get { return _image; } }
    public string Name { get { return _name; } }
    public string Description { get { return _description; } }
    void Awake()
    {
        _image = GetComponent<SpriteRenderer>();
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

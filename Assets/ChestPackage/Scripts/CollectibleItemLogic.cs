using UnityEngine;

public class CollectibleItemLogic : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer _image;
    [SerializeField]
    string _name;
    [SerializeField]
    string _description;
    public SpriteRenderer Image { get { return _image; } }
    public string Name { get { return _name; } }
    public string Description { get { return _description; } }
    public void OnItemPicked()
    {
        Destroy(gameObject);
    }
}

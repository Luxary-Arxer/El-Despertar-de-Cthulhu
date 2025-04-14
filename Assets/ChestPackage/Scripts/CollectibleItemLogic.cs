using UnityEngine;

public class CollectibleItemLogic : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer image;
    public SpriteRenderer Image { get { return image; } }
    public void OnItemPicked(){        
        Destroy(gameObject);
    }
}

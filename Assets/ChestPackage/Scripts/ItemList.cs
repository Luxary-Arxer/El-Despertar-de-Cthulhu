using UnityEngine;

public class ItemList : MonoBehaviour
{
    [SerializeField]
    GameObject[] _whiteItems;
    [SerializeField]
    GameObject[] _greenItems;
    [SerializeField]
    GameObject[] _blueItems;
    [SerializeField]
    GameObject[] _purpleItems;
    [SerializeField]
    GameObject[] _yellowItems;

    public GameObject[] WhiteItems { get { return _whiteItems; } }
    public GameObject[] GreenItems { get { return _greenItems; } }
    public GameObject[] BlueItems { get { return _blueItems; } }
    public GameObject[] PurpleItems { get { return _purpleItems; } }
    public GameObject[] YellowItems { get { return _yellowItems; } }

}

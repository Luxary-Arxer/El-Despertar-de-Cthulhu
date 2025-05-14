using UnityEngine;

public class RoomVisibilitySwitcher : MonoBehaviour
{
    [SerializeField]
    GameObject _enteringRoom;
    [SerializeField]
    GameObject _leavingRoom;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _enteringRoom.SetActive(true);
            _leavingRoom.SetActive(false);
        }
    }
}

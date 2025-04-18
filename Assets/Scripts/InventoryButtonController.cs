
using UnityEngine;

public class InventoryButtonController : MonoBehaviour
{
    [SerializeField]
    GameObject _hintsInventory;
    [SerializeField]
    GameObject _itemsInventory;
    [SerializeField]
    GameObject _logsInventory;
    
    public void SwitchToHintsInventory()
    {
        _hintsInventory.SetActive(true);

        _itemsInventory.SetActive(false);
        _logsInventory.SetActive(false);
    }
    public void SwitchToItemInventory()
    {
        _itemsInventory.SetActive(true);

        _hintsInventory.SetActive(false);
        _logsInventory.SetActive(false);
    }
    public void SwitchToLogsInventory()
    {
        _logsInventory.SetActive(true);

        _hintsInventory.SetActive(false);
        _itemsInventory.SetActive(false);
    }
}

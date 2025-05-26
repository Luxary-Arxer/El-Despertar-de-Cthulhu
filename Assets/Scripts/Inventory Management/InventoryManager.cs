
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [Header("Starter items")]
    [SerializeField]
    ItemObject _daggerItem;
    [SerializeField]
    LogObject _letterLog;

    [Header("Inventory slots")]
    [SerializeField]
    GameObject[] _itemSlots;
    [SerializeField]
    GameObject[] _logsSlots;
    [SerializeField]
    GameObject[] _hintsSlots;

    void OnEnable()
    {
        UpdateItemInventoryUI();
        UpdateHintInventoryUI();
        UpdateLogInventoryUI();
    }
    void Awake()
    {
        AddItemToInventory(_daggerItem);
        AddLogToInventory(_letterLog);
    }
    public void AddItemToInventory(ItemObject item)
    {
        if (!InventoryGenerator.ItemsInventory.Contains(item))
        {
            if (InventoryGenerator.ItemsInventory.Count < _itemSlots.Length)
            {
                InventoryGenerator.ItemsInventory.Add(item);

                UpdateItemInventoryUI();
            }
            else
            {
                Debug.Log("¡No hay espacio en el inventario!");
            }
        }
    }
    public void AddHintToInventory(HintObject hint)
    {
        if (!InventoryGenerator.HintsInventory.Contains(hint))
        {
            if (InventoryGenerator.HintsInventory.Count < _hintsSlots.Length)
            {
                InventoryGenerator.HintsInventory.Add(hint);

                UpdateHintInventoryUI();
            }
            else
            {
                Debug.Log("¡No hay espacio en el inventario!");
            }
        }
    }
    public void AddLogToInventory(LogObject log)
    {
        if (!InventoryGenerator.LogsInventory.Contains(log))
        {
            if (InventoryGenerator.LogsInventory.Count < _logsSlots.Length)
            {
                InventoryGenerator.LogsInventory.Add(log);

                UpdateLogInventoryUI();
            }
            else
            {
                Debug.Log("¡No hay espacio en el inventario!");
            }
        }
    }
    void UpdateItemInventoryUI()
    {
        for (int i = 0; i < _itemSlots.Length && i < InventoryGenerator.ItemsInventory.Count; i++)
        {
            ItemSlotManager currentItem = _itemSlots[i].GetComponent<ItemSlotManager>();
            currentItem.ItemImage = InventoryGenerator.ItemsInventory[i].Image;
            currentItem.ItemName = InventoryGenerator.ItemsInventory[i].Name;
            currentItem.ItemDescription = InventoryGenerator.ItemsInventory[i].Description;
            currentItem.DisplayImageOnInventory();
        }
    }
    void UpdateLogInventoryUI()
    {
        for (int i = 0; i < _logsSlots.Length && i < InventoryGenerator.LogsInventory.Count; i++)
        {
            ItemSlotManager currentLog = _logsSlots[i].GetComponent<ItemSlotManager>();
            currentLog.ItemImage = InventoryGenerator.LogsInventory[i].Image;
            currentLog.ItemName = InventoryGenerator.LogsInventory[i].Name;
            currentLog.ItemDescription = InventoryGenerator.LogsInventory[i].Log;
            currentLog.DisplayImageOnInventory();
        }
    }
    void UpdateHintInventoryUI()
    {
        for (int i = 0; i < _hintsSlots.Length && i < InventoryGenerator.HintsInventory.Count; i++)
        {
            HintSlotManager currentHint = _hintsSlots[i].GetComponent<HintSlotManager>();
            currentHint.HintName = InventoryGenerator.HintsInventory[i].Name;
            currentHint.HintDescription = InventoryGenerator.HintsInventory[i].Hint;
            currentHint.DisplayTextOnInventory();
        }        
    }
}

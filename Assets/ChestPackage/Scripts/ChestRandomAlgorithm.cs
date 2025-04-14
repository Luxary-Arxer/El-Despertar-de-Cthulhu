using UnityEngine;

public class ChestRandomAlgorithm : MonoBehaviour
{
    [SerializeField]
    Transform _spawnPoint;
    [SerializeField]
    GameObject _sphereCollider;
    ItemList _itemList;
    void Awake()
    {
        _itemList = GetComponent<ItemList>();
    }
    public void OnChestOpen()
    {
        _sphereCollider.SetActive(false);
        
        float randomNumberItemTier = Random.value;

        if (randomNumberItemTier >= 0 && randomNumberItemTier < .45f)
        {
            SpawnRandomItem("WhiteItems");
        }
        else if (randomNumberItemTier >= .45f && randomNumberItemTier < .75f)
        {
            SpawnRandomItem("GreenItems");
        }
        else if (randomNumberItemTier >= .75f && randomNumberItemTier < .9f)
        {
            SpawnRandomItem("BlueItems");
        }
        else if (randomNumberItemTier >= .9f && randomNumberItemTier < .98f)
        {
            SpawnRandomItem("PurpleItems");
        }
        else
        {
            SpawnRandomItem("YellowItems");
        }
    }
    void SpawnRandomItem(string selectedArray)
    {
        switch (selectedArray)
        {
            case "WhiteItems":
                int randomNumberWhiteItemSelector = Random.Range(0, _itemList.WhiteItems.Length);
                Instantiate(_itemList.WhiteItems[randomNumberWhiteItemSelector], _spawnPoint.position, _spawnPoint.rotation);
                break;
            case "GreenItems":
                int randomNumberGreenItemSelector = Random.Range(0, _itemList.GreenItems.Length);
                Instantiate(_itemList.GreenItems[randomNumberGreenItemSelector], _spawnPoint.position, _spawnPoint.rotation);
                break;
            case "BlueItems":
                int randomNumberBlueItemSelector = Random.Range(0, _itemList.BlueItems.Length);
                Instantiate(_itemList.BlueItems[randomNumberBlueItemSelector], _spawnPoint.position, _spawnPoint.rotation);
                break;
            case "PurpleItems":
                int randomNumberPurpleItemSelector = Random.Range(0, _itemList.PurpleItems.Length);
                Instantiate(_itemList.PurpleItems[randomNumberPurpleItemSelector], _spawnPoint.position, _spawnPoint.rotation);
                break;
            case "YellowItems":
                int randomNumberYellowItemSelector = Random.Range(0, _itemList.YellowItems.Length);
                Instantiate(_itemList.YellowItems[randomNumberYellowItemSelector], _spawnPoint.position, _spawnPoint.rotation);
                break;
        }
    }
}

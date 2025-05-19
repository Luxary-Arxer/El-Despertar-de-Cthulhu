
using UnityEngine;
using DialogueEditor;

public class QuestManager : MonoBehaviour
{
    InventoryManager _inventoryManager;

    //Generals death markers
    public static bool IsKorbyDead;
    public static bool IsBifiaDead;
    public static bool IsEphrieDead;
    public static bool IsEurialeDead;

    //Library forbidden room Sidequest
    public static bool HasPasswordLibraryRoom;

    //Korby death quest
    public static bool HasRatsInfo;
    public static bool ReachedFinalNodeChefConversation;
    [Header("Korby quest")]
    [SerializeField]
    GameObject _chefGameObject;

    //Bifia death quest
    public static bool HasFailedToSayJanitorPassword;
    public static bool ReachedFinalNodeBifiaConversation;
    [Header("Bifia quest")]
    [SerializeField]
    ItemObject _bifiaKey;

    //Ephrie death quest

    //Euriale death quest

    void Awake()
    {
        _inventoryManager = GetComponent<InventoryManager>();
    }

    //Library forbidden room Sidequest
    public void CheckPasswordLibraryForbiddenRoom()
    {
        if (HasPasswordLibraryRoom)
            ConversationManager.Instance.SetBool("HasPasswordLibraryRoom", true);
    }
    public void GetHintLibraryForbiddenRoom()
    {
        //get the hint
    }
    public void GetHintPasswordLibraryForbiddenRoom()
    {
        //get the hint
    }
    public void GetPasswordLibraryForbiddenRoom()
    {
        HasPasswordLibraryRoom = true;
    }
    public void UnlockLibraryForbiddenRoom()
    {
        //unlock the forbidden room
    }

    //Korby death quest
    public void CheckRatsInfo()
    {
        if (HasRatsInfo)
            ConversationManager.Instance.SetBool("HasRatsInfo", true);
    }
    public void GetRatsInfo()
    {
        HasRatsInfo = true;
    }
    public void HasReachedFinalNodeChefConversation()
    {
        ReachedFinalNodeChefConversation = true;
    }

    //Bifia death quest
    public void GetBifiaRoomKey()
    {
        _inventoryManager.AddItemToInventory(_bifiaKey);
    }
    public void HasReachedFinalNodeBifiaConversation()
    {
        ReachedFinalNodeBifiaConversation = true;
    }
    public void CheckJanitorPasswordFail()
    {
        if (HasFailedToSayJanitorPassword)
            ConversationManager.Instance.SetBool("HasFailedPassword", true);
    }
    public void FailedToSayJanitorPassword()
    {
        HasFailedToSayJanitorPassword = true;
    }
}

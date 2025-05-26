
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
    public static bool ReachedFinalNodeDishConversation;
    public static bool ReachedFinalNodeKorbyDeathConversation;
    [Header("Korby quest")]
    [SerializeField]
    GameObject _chefGameObject;
    [SerializeField]
    ItemObject _apple;
    [SerializeField]
    HintObject _ratLoverHint;

    //Bifia death quest
    public static bool HasFailedToSayJanitorPassword;
    public static bool ReachedFinalNodeJanitorConversation;
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
        _inventoryManager.AddHintToInventory(_ratLoverHint);
    }
    public void HasReachedFinalNodeChefConversation()
    {
        ReachedFinalNodeChefConversation = true;
    }
    public void CheckAppleOnInventory()
    {
        if (InventoryGenerator.ItemsInventory.Contains(_apple))
            ConversationManager.Instance.SetBool("HasApple", true);
    }
    public void HasReachedFinalNodeDishConversation()
    {
        ReachedFinalNodeDishConversation = true;
    }
    public void HasReachedFinalNodeKorbyDeathConversation()
    {
        ReachedFinalNodeKorbyDeathConversation = true;
    }

    //Bifia death quest
    public void HasReachedFinalNodeBifiaConversation()
    {
        ReachedFinalNodeBifiaConversation = true;
    }
    public void HasReachedFinalNodeJanitorConversation()
    {
        ReachedFinalNodeJanitorConversation = true;

        _inventoryManager.AddItemToInventory(_bifiaKey);
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

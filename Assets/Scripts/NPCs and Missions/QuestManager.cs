
using UnityEngine;
using DialogueEditor;

public class QuestManager : MonoBehaviour
{
    InventoryManager _inventoryManager;
    CharacterAudioManager _characterAudioManager;

    //Generals death markers
    public static bool IsKorbyDead;
    public static bool IsBifiaDead;
    public static bool IsEphrieDead;
    public static bool IsEurialeDead;

    //Library forbidden room Sidequest
    public static bool HasPasswordLibraryRoom;
    [SerializeField]
    HintObject _forbiddenRoomHint;
    [SerializeField]
    HintObject _passwordHint;

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
    [SerializeField]
    HintObject _chefHint;

    //Bifia death quest
    public static bool HasFailedToSayJanitorPassword;
    public static bool ReachedFinalNodeJanitorConversation;
    public static bool ReachedFinalNodeBifiaConversation;
    public static bool ReachedFinalNodeBifiaDoorConversation;
    public static bool IsBifiaDoorOpened;
    [Header("Bifia quest")]
    [SerializeField]
    ItemObject _bifiaKey;

    //Ephrie death quest

    //Euriale death quest

    void Awake()
    {
        _inventoryManager = GetComponent<InventoryManager>();
        _characterAudioManager = GetComponent<CharacterAudioManager>();
    }

    //Library forbidden room Sidequest
    public void CheckPasswordLibraryForbiddenRoom()
    {
        if (HasPasswordLibraryRoom)
            ConversationManager.Instance.SetBool("HasPasswordLibraryRoom", true);
    }
    public void GetHintLibraryForbiddenRoom()
    {
        if (!InventoryGenerator.HintsInventory.Contains(_forbiddenRoomHint))
        {
            _inventoryManager.AddHintToInventory(_forbiddenRoomHint);
            ReproduceGetHintSound();
        }
    }
    public void GetHintPasswordLibraryForbiddenRoom()
    {
        if (!InventoryGenerator.HintsInventory.Contains(_passwordHint))
        {
            _inventoryManager.AddHintToInventory(_passwordHint);
            ReproduceGetHintSound();
        }
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
    public void GetChefInfo()
    {
        if (!InventoryGenerator.HintsInventory.Contains(_chefHint))
        {
            _inventoryManager.AddHintToInventory(_chefHint);
            ReproduceGetHintSound();
        }
    }
    public void CheckRatsInfo()
    {
        if (HasRatsInfo)
            ConversationManager.Instance.SetBool("HasRatsInfo", true);
    }
    public void GetRatsInfo()
    {
        if (!InventoryGenerator.HintsInventory.Contains(_ratLoverHint))
        {
            if (InventoryGenerator.HintsInventory.Contains(_chefHint))
            {
                InventoryGenerator.HintsInventory.Remove(_chefHint);
            }
            _inventoryManager.AddHintToInventory(_ratLoverHint);
            ReproduceGetHintSound();
            HasRatsInfo = true;
        }
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
    public void CheckBifiaKey()
    {
        if (InventoryGenerator.ItemsInventory.Contains(_bifiaKey) && !IsBifiaDead)
        {
            ConversationManager.Instance.SetBool("HasBifiaKey", true);
        }
    }
    public void HasReachedFinalNodeBifiaDoorConversation()
    {
        ReachedFinalNodeBifiaDoorConversation = true;
    }
    
    void ReproduceGetHintSound()
    {
        _characterAudioManager.PlaySound(_characterAudioManager.AudioClips[3], false, .75f, 1);
    }
}

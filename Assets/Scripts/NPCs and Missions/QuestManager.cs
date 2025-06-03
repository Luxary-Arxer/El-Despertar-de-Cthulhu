
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

    //Library forbidden room sidequest
    public static bool ReachedFinalNodeLibrarianConverastion;
    [Header("Librarian quest")]
    [SerializeField]
    HintObject _forbiddenRoomHint;
    [SerializeField]
    HintObject _passwordHint;

    //Library laboratory sidequest
    public static bool ReachedFinalNodeGuardianConversation;
    [Header("Laboratory quest")]
    [SerializeField]
    HintObject _firstSecondNumberHint;
    [SerializeField]
    HintObject _thirdNumberHint;
    [SerializeField]
    HintObject _fourthNumberHint;
    [SerializeField]
    HintObject _fullCodeHint;

    //Korby death quest
    public static bool ReachedFinalNodeChefConversation;
    public static bool ReachedFinalNodeDishConversation;
    public static bool ReachedFinalNodeKorbyDeathConversation;
    [Header("Korby quest")]
    [SerializeField]
    ItemObject _appleObject;
    [SerializeField]
    HintObject _ratLoverHint;
    [SerializeField]
    HintObject _chefHint;
    [SerializeField]
    HintObject _appleUseHint;
    [SerializeField]
    HintObject _pickUpAppleHint;

    //Bifia death quest
    public static bool HasFailedToSayJanitorPassword;
    public static bool ReachedFinalNodeJanitorConversation;
    public static bool ReachedFinalNodeBifiaConversation;
    public static bool ReachedFinalNodeBifiaDoorConversation;
    public static bool ReachedFinalNodePostBifiaDeathConversation;
    [Header("Bifia quest")]
    [SerializeField]
    ItemObject _bifiaKeyObject;
    [SerializeField]
    HintObject _firstHalfJanitorCodeHint;
    [SerializeField]
    HintObject _secondHalfJanitorCodeHint;
    [SerializeField]
    HintObject _fullJanitorCodeHint;

    //Ephrie death quest
    public static int WarehouseCrystalsDiscovered;
    public static bool FoundFirstCrystal;
    public static bool FoundSecondCrystal;
    public static bool FoundThirdCrystal;
    public static bool HasPlantBait;
    public static bool ReachedFinalNodeEphrieConversation;
    public static bool ReachedFinalNodePlantConversation;
    public static bool ReachedFinalNodeLogPlantConversation;
    [Header("Ephrie quest")]
    [SerializeField]
    ItemObject _sashijivaFang;
    [SerializeField]
    LogObject _ephrieLog;
    [SerializeField]
    HintObject _unorderedWarehouseHint;
    [SerializeField]
    HintObject _lostFangHint;
    [SerializeField]
    HintObject _fangInPlantHint;
    [SerializeField]
    HintObject _jefHint;
    [SerializeField]
    HintObject _fangLocationHint;

    //Euriale death quest
    public static bool ReachedFinalNodeEurialeConversation;
    [Header("Euríale quest")]
    [SerializeField]
    ItemObject _perseusShield;

    //Endgame stuff
    [Header("Endgame images")]
    [SerializeField]
    GameObject _victoryImage;
    [SerializeField]
    GameObject _defeatImage;
    [SerializeField]
    GameObject _blackBackgroundImage;
    [SerializeField]
    GameObject _endgameDialogueBackground;
    public static bool ReachedFinalNodeVictoryConversation;
    public static bool ReachedFinalNodeDefeatConversation;

    void Awake()
    {
        _inventoryManager = GetComponent<InventoryManager>();
        _characterAudioManager = GetComponent<CharacterAudioManager>();
    }

    //Library forbidden room Sidequest
    public void CheckPasswordLibraryForbiddenRoom()
    {
        if (InventoryGenerator.HintsInventory.Contains(_passwordHint))
            ConversationManager.Instance.SetBool("HasPasswordLibraryRoom", true);
    }
    public void GetHintLibraryForbiddenRoom()
    {
        if (!InventoryGenerator.HintsInventory.Contains(_forbiddenRoomHint) && !InventoryGenerator.HintsInventory.Contains(_passwordHint))
        {
            _inventoryManager.AddHintToInventory(_forbiddenRoomHint);
            ReproduceGetHintSound();
        }
    }
    public void GetHintPasswordLibraryForbiddenRoom()
    {
        if (!InventoryGenerator.HintsInventory.Contains(_passwordHint))
        {
            if (InventoryGenerator.HintsInventory.Contains(_forbiddenRoomHint))
            {
                InventoryGenerator.HintsInventory.Remove(_forbiddenRoomHint);
            }
            _inventoryManager.AddHintToInventory(_passwordHint);
            ReproduceGetHintSound();
        }
    }
    public void HasReachedFinalNodeLibrarianConverastion()
    {
        ReachedFinalNodeLibrarianConverastion = true;
    }

    //Korby death quest
    public void GetChefHint()
    {
        if (!InventoryGenerator.HintsInventory.Contains(_chefHint) && !InventoryGenerator.HintsInventory.Contains(_ratLoverHint))
        {
            _inventoryManager.AddHintToInventory(_chefHint);
            ReproduceGetHintSound();
        }
    }
    public void GetAppleRealUseHint()
    {
        if (!InventoryGenerator.HintsInventory.Contains(_appleUseHint))
        {
            InventoryGenerator.HintsInventory.Remove(_pickUpAppleHint);
            _inventoryManager.AddHintToInventory(_appleUseHint);
            ReproduceGetHintSound();
        }
    }
    public void CheckRatsInfo()
    {
        if (InventoryGenerator.HintsInventory.Contains(_ratLoverHint))
            ConversationManager.Instance.SetBool("HasRatsInfo", true);
    }
    public void GetRatsHint()
    {
        if (!InventoryGenerator.HintsInventory.Contains(_ratLoverHint))
        {
            if (InventoryGenerator.HintsInventory.Contains(_chefHint))
            {
                InventoryGenerator.HintsInventory.Remove(_chefHint);
            }
            _inventoryManager.AddHintToInventory(_ratLoverHint);
            ReproduceGetHintSound();
        }
    }
    public void HasReachedFinalNodeChefConversation()
    {
        ReachedFinalNodeChefConversation = true;
    }
    public void CheckAppleOnInventory()
    {
        if (InventoryGenerator.ItemsInventory.Contains(_appleObject))
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

        _inventoryManager.AddItemToInventory(_bifiaKeyObject);
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
    public void GetFirstHalfJanitorCode()
    {
        if (!InventoryGenerator.HintsInventory.Contains(_fullJanitorCodeHint) && !InventoryGenerator.HintsInventory.Contains(_firstHalfJanitorCodeHint))
        {
            if (InventoryGenerator.HintsInventory.Contains(_secondHalfJanitorCodeHint))
            {
                InventoryGenerator.HintsInventory.Remove(_secondHalfJanitorCodeHint);
                _inventoryManager.AddHintToInventory(_fullJanitorCodeHint);
            }
            else
            {
                _inventoryManager.AddHintToInventory(_firstHalfJanitorCodeHint);
            }
            ReproduceGetHintSound();
        }
    }
    public void GetSecondHalfJanitorCode()
    {
        if (!InventoryGenerator.HintsInventory.Contains(_fullJanitorCodeHint) && !InventoryGenerator.HintsInventory.Contains(_secondHalfJanitorCodeHint))
        {
            if (InventoryGenerator.HintsInventory.Contains(_firstHalfJanitorCodeHint))
            {
                InventoryGenerator.HintsInventory.Remove(_firstHalfJanitorCodeHint);
                _inventoryManager.AddHintToInventory(_fullJanitorCodeHint);
            }
            else
            {
                _inventoryManager.AddHintToInventory(_secondHalfJanitorCodeHint);
                ReproduceGetHintSound();
            }
        }
    }
    public void CheckBifiaKey()
    {
        if (InventoryGenerator.ItemsInventory.Contains(_bifiaKeyObject) && !IsBifiaDead)
        {
            ConversationManager.Instance.SetBool("HasBifiaKey", true);
        }
    }
    public void HasReachedFinalNodeBifiaDoorConversation()
    {
        ReachedFinalNodeBifiaDoorConversation = true;
    }
    public void HasReachedFinalNodePostBifiaDeathConversation()
    {
        ReachedFinalNodePostBifiaDeathConversation = true;
    }

    //Ephrie death quest
    public void HasFoundFirstCrystal()
    {
        if (!FoundFirstCrystal)
        {
            FoundFirstCrystal = true;
            WarehouseCrystalsDiscovered++;
        }
    }
    public void HasFoundSecondCrystal()
    {
        if (!FoundSecondCrystal)
        {
            FoundSecondCrystal = true;
            WarehouseCrystalsDiscovered++;
        }
    }
    public void HasFoundThirdCrystal()
    {
        if (!FoundThirdCrystal)
        {
            FoundThirdCrystal = true;
            WarehouseCrystalsDiscovered++;
        }
    }
    public void CheckCrystalAmount()
    {
        if (WarehouseCrystalsDiscovered >= 3)
        {
            ConversationManager.Instance.SetBool("HasFoundCrystals", true);
        }
    }
    public void CheckFangInInventory()
    {
        if (InventoryGenerator.ItemsInventory.Contains(_sashijivaFang))
        {
            ConversationManager.Instance.SetBool("HasFang", true);
        }
    }
    public void CheckPlantInfo()
    {
        if (InventoryGenerator.HintsInventory.Contains(_fangLocationHint) || InventoryGenerator.HintsInventory.Contains(_lostFangHint) || InventoryGenerator.HintsInventory.Contains(_fangInPlantHint))
        {
            ConversationManager.Instance.SetBool("HasPlantInfo", true);
        }
    }
    public void CheckBait()
    {
        if (HasPlantBait)
        {
            ConversationManager.Instance.SetBool("HasBait", true);
        }
    }
    public void UseBait()
    {
        HasPlantBait = false;
    }
    public void GetFangItem()
    {
        if (!InventoryGenerator.HintsInventory.Contains(_fangInPlantHint))
        {
            InventoryGenerator.HintsInventory.Remove(_lostFangHint);
            _inventoryManager.AddHintToInventory(_fangInPlantHint);
            ReproduceGetHintSound();
        }
        ReachedFinalNodePlantConversation = true;
        _inventoryManager.AddItemToInventory(_sashijivaFang);
    }
    public void GetEphrieLog()
    {
        ReachedFinalNodeLogPlantConversation = true;
        _inventoryManager.AddLogToInventory(_ephrieLog);
    }
    public void HasReachedFinalNodeEphrieConversation()
    {
        ReachedFinalNodeEphrieConversation = true;
    }
    public void GetWarehouseHint()
    {
        if (!InventoryGenerator.HintsInventory.Contains(_unorderedWarehouseHint) && !InventoryGenerator.HintsInventory.Contains(_lostFangHint) && !InventoryGenerator.HintsInventory.Contains(_fangInPlantHint))
        {
            _inventoryManager.AddHintToInventory(_unorderedWarehouseHint);
            ReproduceGetHintSound();
        }
    }
    public void GetLostFangHint()
    {
        if (!InventoryGenerator.HintsInventory.Contains(_lostFangHint) && !InventoryGenerator.HintsInventory.Contains(_fangInPlantHint))
        {
            if (InventoryGenerator.HintsInventory.Contains(_unorderedWarehouseHint))
            {
                InventoryGenerator.HintsInventory.Remove(_unorderedWarehouseHint);
            }
            HasPlantBait = true;
            _inventoryManager.AddHintToInventory(_lostFangHint);
            ReproduceGetHintSound();
        }
    }
    public void GetFangInPlantHint()
    {
        if (!InventoryGenerator.HintsInventory.Contains(_fangInPlantHint))
        {
            InventoryGenerator.HintsInventory.Remove(_lostFangHint);
            _inventoryManager.AddHintToInventory(_fangInPlantHint);
            ReproduceGetHintSound();
        }
    }
    public void GetJefHint()
    {
        if (!InventoryGenerator.HintsInventory.Contains(_jefHint) && !InventoryGenerator.HintsInventory.Contains(_fangLocationHint) && !InventoryGenerator.HintsInventory.Contains(_lostFangHint) && !InventoryGenerator.HintsInventory.Contains(_fangInPlantHint))
        {
            _inventoryManager.AddHintToInventory(_jefHint);
            ReproduceGetHintSound();
        }
    }
    public void GetFangLocationHint()
    {
        if (!InventoryGenerator.HintsInventory.Contains(_fangLocationHint))
        {
            if (InventoryGenerator.HintsInventory.Contains(_jefHint))
            {
                InventoryGenerator.HintsInventory.Remove(_jefHint);
            }
            _inventoryManager.AddHintToInventory(_fangLocationHint);
            ReproduceGetHintSound();
        }
    }

    //Euriale death quest    
    public void CheckHasShield()
    {
        if (InventoryGenerator.ItemsInventory.Contains(_perseusShield))
        {
            ConversationManager.Instance.SetBool("HasShield", true);
        }
    }
    public void CheckHasFullLabCode()
    {
        if (InventoryGenerator.HintsInventory.Contains(_fullCodeHint))
        {
            ConversationManager.Instance.SetBool("HasFullCode", true);
        }
    }
    public void HasReachedFinalNodeEurialeConversation()
    {
        ReachedFinalNodeEurialeConversation = true;
    }

    //Library laboratory sidequest
    public void GetFirstSecondNumberHint()
    {
        if (!InventoryGenerator.HintsInventory.Contains(_firstSecondNumberHint))
        {
            if (InventoryGenerator.HintsInventory.Contains(_thirdNumberHint) && InventoryGenerator.HintsInventory.Contains(_fourthNumberHint))
            {
                InventoryGenerator.HintsInventory.Remove(_thirdNumberHint);
                InventoryGenerator.HintsInventory.Remove(_fourthNumberHint);
                _inventoryManager.AddHintToInventory(_fullCodeHint);
                ReproduceGetHintSound();
            }
            else if (!InventoryGenerator.HintsInventory.Contains(_fullCodeHint))
            {
                _inventoryManager.AddHintToInventory(_firstSecondNumberHint);
                ReproduceGetHintSound();
            }
        }
    }
    public void GetThirdNumberHint()
    {
        if (!InventoryGenerator.HintsInventory.Contains(_thirdNumberHint))
        {
            if (InventoryGenerator.HintsInventory.Contains(_firstSecondNumberHint) && InventoryGenerator.HintsInventory.Contains(_fourthNumberHint))
            {
                InventoryGenerator.HintsInventory.Remove(_firstSecondNumberHint);
                InventoryGenerator.HintsInventory.Remove(_fourthNumberHint);
                _inventoryManager.AddHintToInventory(_fullCodeHint);
                ReproduceGetHintSound();
            }
            else if (!InventoryGenerator.HintsInventory.Contains(_fullCodeHint))
            {
                _inventoryManager.AddHintToInventory(_thirdNumberHint);
                ReproduceGetHintSound();
            }
        }
    }
    public void GetFourthNumberHint()
    {
        if (!InventoryGenerator.HintsInventory.Contains(_fourthNumberHint))
        {
            if (InventoryGenerator.HintsInventory.Contains(_firstSecondNumberHint) && InventoryGenerator.HintsInventory.Contains(_thirdNumberHint))
            {
                InventoryGenerator.HintsInventory.Remove(_firstSecondNumberHint);
                InventoryGenerator.HintsInventory.Remove(_thirdNumberHint);
                _inventoryManager.AddHintToInventory(_fullCodeHint);
                ReproduceGetHintSound();
            }
            else if (!InventoryGenerator.HintsInventory.Contains(_fullCodeHint))
            {
                _inventoryManager.AddHintToInventory(_fourthNumberHint);
                ReproduceGetHintSound();
            }
        }
    }
    public void HasReachedFinalNodeGuardianConversation()
    {
        ReachedFinalNodeGuardianConversation = true;
    }

    //Endgame functions
    public void PopVictoryImage()
    {
        _victoryImage.SetActive(true);
        _blackBackgroundImage.SetActive(false);
        _endgameDialogueBackground.SetActive(true);
    }
    public void PopDefeatImage()
    {
        _defeatImage.SetActive(true);
        _blackBackgroundImage.SetActive(false);
        _endgameDialogueBackground.SetActive(true);
    }
    public void PopBlackImage()
    {
        _blackBackgroundImage.SetActive(true);
        _endgameDialogueBackground.SetActive(true);
    }
    public void HasReachedFinalNodeDefeatConversation()
    {
        ReachedFinalNodeDefeatConversation = true;
    }
    public void HasReachedFinalNodeVictoryConversation()
    {
        ReachedFinalNodeVictoryConversation = true;
    }

    void ReproduceGetHintSound()
    {
        _characterAudioManager.PlaySound(_characterAudioManager.AudioClips[3], false, .75f, 1);
    }
}

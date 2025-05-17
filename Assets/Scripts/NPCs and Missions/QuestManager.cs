
using UnityEngine;
using DialogueEditor;
using System.Collections;

public class QuestManager : MonoBehaviour
{

    //Library forbidden room Sidequest
    public static bool HasPasswordLibraryRoom;

    //Korby death quest
    public static bool HasRatsInfo;
    public static bool ReachedFinalNodeChefConversation;
    [SerializeField]
    GameObject _chefGameObject;

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
}

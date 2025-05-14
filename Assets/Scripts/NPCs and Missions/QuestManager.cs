
using UnityEngine;
using DialogueEditor;

public class QuestManager : MonoBehaviour
{
    //Library forbidden room Sidequest
    bool _hasPasswordLibraryRoom;

    //Library forbidden room Sidequest
    public void CheckPasswordLibraryForbiddenRoom()
    {
        if (_hasPasswordLibraryRoom)
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
        _hasPasswordLibraryRoom = true;
    }
    public void UnlockLibraryForbiddenRoom()
    {
        //unlock the forbidden room
    }
}

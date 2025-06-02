
using UnityEngine.SceneManagement;

public class DaytimeTracker  
{
    public static int MomentOfTheDay=2;

    public static void RestartDay()
    {
        InventoryManager.ResetItemInventory();

        QuestManager.IsKorbyDead = false;
        QuestManager.IsBifiaDead = false;
        QuestManager.IsEphrieDead = false;
        QuestManager.IsEurialeDead = false;

        QuestManager.HasFailedToSayJanitorPassword = false;

        MomentOfTheDay = 0;
        SceneManager.LoadScene(1);
    }
    public static void AdvanceThroughTheDay()
    {
        MomentOfTheDay++;
    }
}

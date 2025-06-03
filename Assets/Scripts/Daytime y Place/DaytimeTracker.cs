
using UnityEngine.SceneManagement;

public class DaytimeTracker
{
    public static int MomentOfTheDay;

    public static void AdvanceThroughTheDay()
    {
        MomentOfTheDay++;
    }
    public static void RestartDay()
    {
        ResetEverything();
        SceneManager.LoadScene(1);
    }
    public static void RestartGame()
    {
        ResetEverything();
        SceneManager.LoadScene(0);
    }

    static void ResetEverything()
    {
        InventoryManager.ResetItemInventory();

        QuestManager.IsKorbyDead = false;
        QuestManager.IsBifiaDead = false;
        QuestManager.IsEphrieDead = false;
        QuestManager.IsEurialeDead = false;

        QuestManager.HasFailedToSayJanitorPassword = false;
        
        QuestManager.FoundFirstCrystal = false;
        QuestManager.FoundSecondCrystal = false;
        QuestManager.FoundThirdCrystal = false;

        MomentOfTheDay = 0;
    }
}

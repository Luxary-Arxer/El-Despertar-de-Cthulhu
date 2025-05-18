
public class DaytimeTracker  
{
    public static int MomentOfTheDay;

    public static void RestartDay()
    {
        MomentOfTheDay = 0;
        
        QuestManager.IsKorbyDead = false;
        QuestManager.IsBifiaDead = false;
        QuestManager.IsEphrieDead = false;
        QuestManager.IsEurialeDead = false;   

        QuestManager.HasFailedToSayJanitorPassword = false;
    }
    public static void AdvanceThroughTheDay()
    {
        MomentOfTheDay++;
    }
}

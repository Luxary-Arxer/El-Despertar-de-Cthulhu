
using UnityEngine;

public class DaytimeTracker : MonoBehaviour 
{
    public static int MomentOfTheDay;

    public static void RestartDay()
    {
        MomentOfTheDay = 0;
    }
    public static void AdvanceThroughTheDay()
    {
        MomentOfTheDay++;
    }
}

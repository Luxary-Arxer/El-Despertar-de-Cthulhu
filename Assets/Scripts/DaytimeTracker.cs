
using UnityEngine;

public class DaytimeTracker : MonoBehaviour 
{
    //Esto hay que cambiarlo de sitio al menu de selección donde eliges que lugar de la mansión quieres visitar
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

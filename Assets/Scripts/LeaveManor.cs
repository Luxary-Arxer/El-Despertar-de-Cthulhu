
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveManor : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (DaytimeTracker.MomentOfTheDay < 2)
            {
                DaytimeTracker.AdvanceThroughTheDay();
            }
            else
            {
                DaytimeTracker.RestartDay();
            }
            SceneManager.LoadScene(1);
        }
    }
}

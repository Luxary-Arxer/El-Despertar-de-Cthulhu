
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveManor : MonoBehaviour
{
    [SerializeField]   
    GameObject _interactCanvas;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _interactCanvas.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _interactCanvas.SetActive(false);
        }
    }
    public void LeaveManorFunction()
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


using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveCurrentPlace : MonoBehaviour
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
    public void LeaveCurrentPlaceFunction()
    {
        if (DaytimeTracker.MomentOfTheDay < 2)
        {
            DaytimeTracker.AdvanceThroughTheDay();
        }
        else
        {
            GetComponent<EndgameManager>().LoadEndGameScene();
        }
    }
}

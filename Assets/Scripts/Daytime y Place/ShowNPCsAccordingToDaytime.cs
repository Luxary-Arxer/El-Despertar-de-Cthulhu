
using UnityEngine;

public class ShowNPCsAccordingToDaytime : MonoBehaviour
{
    [SerializeField]
    GameObject[] _morningNPCs;
    [SerializeField]
    GameObject[] _eveningNPCs;
    [SerializeField]
    GameObject[] _nightNPCs;

    void Awake()
    {
        switch (DaytimeTracker.MomentOfTheDay)
        {
            case 0:
                TurnOnMorningNPCs();
                break;
            case 1:
                TurnOnEveningNPCs();
                break;
            case 2:
                TurnOnNightNPCs();
                break;
        }
    }
    void TurnOnMorningNPCs()
    {
        for (int i = 0; i < _morningNPCs.Length; i++)
        {
            _morningNPCs[i].SetActive(true);
        }
    }
    void TurnOnEveningNPCs()
    {
        for (int i = 0; i < _eveningNPCs.Length; i++)
        {
            _eveningNPCs[i].SetActive(true);
        }
    }
    void TurnOnNightNPCs()
    {
        for (int i = 0; i < _nightNPCs.Length; i++)
        {
            _nightNPCs[i].SetActive(true);
        }
    }
}

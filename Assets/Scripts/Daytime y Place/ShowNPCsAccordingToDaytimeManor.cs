using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowNPCsAccordingToDaytimeManor : MonoBehaviour
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
                for (int i = 0; i < _eveningNPCs.Lenght; i++)
                {
                    _eveningNPCs[i].SetActive(false);
                }
                for (int i = 0; i < _nightNPCs.Lenght; i++)
                {
                    _nightNPCs[i].SetActive(false);
                }
            break;
            case 1:
                for (int i = 0; i < _morningNPCs.Lenght; i++)
                {
                    _morningNPCs[i].SetActive(false);
                }
                for (int i = 0; i < _nightNPCs.Lenght; i++)
                {
                    _nightNPCs[i].SetActive(false);
                }
            break;
            case 2:
                for (int i = 0; i < _morningNPCs.Lenght; i++)
                {
                    _morningNPCs[i].SetActive(false);
                }
                for (int i = 0; i < _eveningNPCs.Lenght; i++)
                {
                    _eveningNPCs[i].SetActive(false);
                }
            break;
        }
    }
}

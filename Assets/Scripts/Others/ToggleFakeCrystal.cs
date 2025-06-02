
using UnityEngine;

public class ToggleFakeCrystal : MonoBehaviour
{
    GameObject _nameCanvas;
    
    void Awake()
    {       
        _nameCanvas = GetComponentInChildren<Canvas>().gameObject;
        
        _nameCanvas.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _nameCanvas.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _nameCanvas.SetActive(false);
        }
    }
}

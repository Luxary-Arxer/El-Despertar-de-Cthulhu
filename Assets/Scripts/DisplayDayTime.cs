
using UnityEngine;
using UnityEngine.UI;

public class DisplayDayTime : MonoBehaviour
{
    [SerializeField]
    Sprite _daySprite;
    [SerializeField]
    Sprite _eveningSprite;
    [SerializeField]
    Sprite _nightSprite;

    Image _daytimeImage;

    void Awake()
    {
        _daytimeImage = GetComponent<Image>();
    }
    void OnEnable()
    {
        switch (DaytimeTracker.MomentOfTheDay)
        {
            case 0: 
                _daytimeImage.sprite = _daySprite;
            break;
            case 1: 
                _daytimeImage.sprite = _eveningSprite;
            break;
            case 2: 
                _daytimeImage.sprite = _nightSprite;
            break;
        }
    }
}

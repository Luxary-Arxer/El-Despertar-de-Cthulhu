using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    [SerializeField]
    float _fadeSpeed;
    [SerializeField]
    float _waitTime;
    bool _isFinishedFadingOut;
    
    Image _image;
    PlayerInputController _playerInputController;

    void Awake()
    {
        _image = GetComponent<Image>();
        _playerInputController = FindFirstObjectByType<PlayerInputController>();
    }
    void OnEnable()
    {
        _playerInputController.PlayerControlls.Player.Disable();
    }
    void OnDisable()
    {
        if (!QuestManager.ReachedFinalNodeDishConversation)
        {
            _playerInputController.PlayerControlls.Player.Enable();
        }
        _isFinishedFadingOut = false;
    }
    void Update()
    {
        Color color = _image.color;
        if (gameObject.activeInHierarchy && !_isFinishedFadingOut && color.a < 1)
        {
            color.a += Time.deltaTime * _fadeSpeed;
            _image.color = color;
            if (color.a > 1)
            {
                StartCoroutine(WaitAndFadeIn());
            }
        }
        else if (gameObject.activeInHierarchy && _isFinishedFadingOut && color.a > 0)
        {
            color.a -= Time.deltaTime * _fadeSpeed;
            _image.color = color;
            if (color.a < 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
    IEnumerator WaitAndFadeIn()
    {
        yield return new WaitForSeconds(_waitTime);
        _isFinishedFadingOut = true;
    }
}

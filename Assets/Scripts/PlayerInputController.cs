
using UnityEngine;
using UnityEngine.InputSystem;
using DialogueEditor;
using Unity.VisualScripting;

public class PlayerInputController : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField]
    float _characterSpeed;
    [SerializeField]
    float _turnVelocity;
    bool _characterStartedMoving;

    [Header("Objects to move along with the player")]
    [SerializeField]
    Transform _camera;
    [SerializeField]
    Transform _characterSprite;

    [Header("UI Elements")]
    [SerializeField]
    GameObject _pauseMenuUI;
    [SerializeField]
    GameObject _optionsMenuUI;
    [SerializeField]
    GameObject _globalInventoryUI;
    [SerializeField]
    GameObject _hintsInventory;
    [SerializeField]
    GameObject _itemsInventory;
    [SerializeField]
    GameObject _logsInventory;
    [SerializeField]
    GameObject _timeUI;
    [SerializeField]
    GameObject _placeUI;

    public GameObject HintsInventory { get { return _hintsInventory; } }
    public GameObject ItemsInventory { get { return _itemsInventory; } }
    public GameObject LogsInventory { get { return _logsInventory; } }

    public PlayerControllsDefault PlayerControlls;

    InputAction _move;
    InputAction _pause;
    InputAction _interact;
    InputAction _inventory;
    InputAction _back;

    Vector3 _movementInput;

    CharacterController _characterController;
    InventoryManager _inventoryManager;
    CharacterAudioManager _characterAudioManager;

    GameObject _interactableObject;
    public GameObject InteractableObject { get { return _interactableObject; } }

    void Awake()
    {
        PlayerControlls = new PlayerControllsDefault();

        _characterController = GetComponent<CharacterController>();
        _inventoryManager = GetComponent<InventoryManager>();
        _characterAudioManager = GetComponent<CharacterAudioManager>();

        Cursor.visible = false;
    }
    void OnEnable()
    {
        _move = PlayerControlls.Player.Move;
        _pause = PlayerControlls.Player.Pause;
        _interact = PlayerControlls.Player.Interact;
        _inventory = PlayerControlls.Player.Inventory;

        _back = PlayerControlls.UI.Back;

        _move.Enable();
        _pause.Enable();
        _interact.Enable();
        _inventory.Enable();

        _back.Enable();

        _pause.performed += Pause;
        _interact.performed += Interact;
        _inventory.performed += Inventory;

        _back.performed += Back;
    }
    void OnDisable()
    {
        _move.Disable();
        _pause.Disable();
        _interact.Disable();
        _inventory.Disable();

        _back.Disable();
    }

    void Update()
    {
        GatherMovementInput();

        if (IsPlayerMoving())
        {
            CharacterMovement();
            CharacterRotation();

            SpriteMovementRotation();

            CameraMovement();
            SpriteMovement();
            if (!_characterStartedMoving)
            {
                CharacterStartedMoving();
            }
        }
        else if (_characterStartedMoving)
        {
            CharacterStoppedMoving();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        _interactableObject = other.gameObject;
    }
    void OnTriggerExit(Collider other)
    {
        _interactableObject = null;
    }
    void Interact(InputAction.CallbackContext context)
    {
        if (_interactableObject != null)
        {
            string tag = _interactableObject.tag;
            switch (tag)
            {
                case "Leave":
                    _interactableObject.GetComponent<LeaveCurrentPlace>().LeaveCurrentPlaceFunction();
                    break;
                case "Item":
                    if (_interactableObject.GetComponent<ItemAdditionallyGivesHint>())
                    {
                        _inventoryManager.AddHintToInventory(_interactableObject.GetComponent<ItemAdditionallyGivesHint>().HintObject);
                    }
                    _inventoryManager.AddItemToInventory(_interactableObject.GetComponent<ItemPickUp>().Item);
                    _interactableObject.GetComponent<GeneralObjectPickUpManager>().OnObjectPicked();

                    OpenInventoryNotByInputAction();
                    _characterAudioManager.PlaySound(_characterAudioManager.AudioClips[0], false, .75f, 1);

                    _hintsInventory.SetActive(false);
                    _itemsInventory.SetActive(true);
                    _logsInventory.SetActive(false);
                    break;
                case "Log":
                    _inventoryManager.AddLogToInventory(_interactableObject.GetComponent<LogPickUp>().Log);
                    _interactableObject.GetComponent<GeneralObjectPickUpManager>().OnObjectPicked();

                    OpenInventoryNotByInputAction();
                    _characterAudioManager.PlaySound(_characterAudioManager.AudioClips[0], false, .75f, 1);

                    _hintsInventory.SetActive(false);
                    _itemsInventory.SetActive(false);
                    _logsInventory.SetActive(true);
                    break;
                case "NPC":
                    if (!ConversationManager.Instance.IsConversationActive)
                    {
                        _interactableObject.GetComponent<StartTalkToNPC>().BeginConversation();                        
                    }
                    break;
            }
        }
    }
    void Pause(InputAction.CallbackContext context)
    {
        if (!ConversationManager.Instance.IsConversationActive)
        {
            DisablePlayerControlls();            

            _pauseMenuUI.SetActive(true);
            _timeUI.SetActive(false);
            _placeUI.SetActive(false);

            Time.timeScale = 0f;
            Cursor.visible = true;
        }
        else
        {
            ConversationManager.Instance.EndConversation();
        }
    }
    void Inventory(InputAction.CallbackContext context)
    {
        if (!ConversationManager.Instance.IsConversationActive)
        {
            DisablePlayerControlls();
            
            _globalInventoryUI.SetActive(true);
            _timeUI.SetActive(false);
            _placeUI.SetActive(false);

            Time.timeScale = 0f;
            Cursor.visible = true;
        }
        else
        {
            ConversationManager.Instance.EndConversation();
        }
    }
    public void OpenInventoryNotByInputAction()
    {
        CharacterStoppedMoving();
        DisablePlayerControlls();
        
        _globalInventoryUI.SetActive(true);
        _timeUI.SetActive(false);
        _placeUI.SetActive(false);

        Time.timeScale = 0f;
        Cursor.visible = true;
    }
    void Back(InputAction.CallbackContext context)
    {
        EnablePlayerControlls();
        
        _pauseMenuUI.SetActive(false);
        _optionsMenuUI.SetActive(false);
        _globalInventoryUI.SetActive(false);
        _timeUI.SetActive(true);
        _placeUI.SetActive(true);

        Cursor.visible = false;
        Time.timeScale = 1f;
    }
    void GatherMovementInput()
    {
        Vector2 inputVector = _move.ReadValue<Vector2>();
        _movementInput = new(inputVector.x, 0, inputVector.y);
    }
    void CharacterMovement()
    {
        _characterController.Move(_characterSpeed * Time.deltaTime * (transform.forward * _movementInput.normalized.magnitude));
    }
    void CharacterRotation()
    {
        Quaternion appliedRotation = Quaternion.LookRotation(Quaternion.Euler(0, 45, 0) * _movementInput, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, appliedRotation, _turnVelocity * Time.deltaTime);
    }
    void CameraMovement()
    {
        _camera.position = transform.position;
    }
    void SpriteMovement()
    {
        _characterSprite.position = transform.position;
    }
    void SpriteMovementRotation()
    {
        _characterSprite.localEulerAngles = new Vector3(30,45, Mathf.PingPong(Time.time * 120, 40)-20);
    }
    void SpriteMovementRotation_Reset()
    {
        _characterSprite.localEulerAngles = new Vector3(30, 45, 0);
    }
    void CharacterStartedMoving()
    {
        _characterStartedMoving = true;
        _characterAudioManager.PlaySound(_characterAudioManager.AudioClips[1], true, .5f, 1);
    }
    void CharacterStoppedMoving()
    {
        _characterStartedMoving = false;
        _characterAudioManager.StopSound();
        SpriteMovementRotation_Reset();
    }
    public void DisablePlayerControlls()
    {
        PlayerControlls.Player.Disable();
        PlayerControlls.UI.Enable();
    }
    public void EnablePlayerControlls()
    {
        PlayerControlls.Player.Enable();
        PlayerControlls.UI.Disable();
    }
    bool IsPlayerMoving()
    {
        return _move.ReadValue<Vector2>().magnitude > .05f;
    }
}


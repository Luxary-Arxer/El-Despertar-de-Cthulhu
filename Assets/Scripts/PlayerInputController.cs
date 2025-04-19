using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField]
    Transform _camera;

    public PlayerControllsDefault PlayerControlls;

    InputAction _move;
    InputAction _pause;
    InputAction _interact;
    InputAction _inventory;
    InputAction _back;

    Vector3 _movementInput;

    CharacterController _characterController;

    GameObject _interactableObject;
    public GameObject InteractableObject { get { return _interactableObject; } }

    [SerializeField]
    float _characterSpeed;
    [SerializeField]
    float _turnSmoothVelocity;

    [SerializeField]
    GameObject _pauseMenu;
    [SerializeField]
    GameObject _inventoryUI;
    [SerializeField]
    GameObject _time;
    [SerializeField]
    GameObject _place;

    void Awake()
    {
        PlayerControlls = new PlayerControllsDefault();
        _characterController = GetComponent<CharacterController>();

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

            CameraMovement();
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
                    _interactableObject.GetComponent<LeaveManor>().LeaveManorFunction();
                    break;
                case "Item":
                    ItemPickUp pickedItem = _interactableObject.GetComponent<ItemPickUp>();
                    GetComponent<InventoryManager>().AddItemToInventory(pickedItem.Image, pickedItem.Name, pickedItem.Description);
                    pickedItem.OnItemPicked();
                    break;
                case "NPC":
                    _interactableObject.GetComponent<TalkToNPC>().StartTalkToNPC();
                    break;
            }
        }
    }
    void Pause(InputAction.CallbackContext context)
    {
        PlayerControlls.Player.Disable();
        PlayerControlls.UI.Enable();
        _pauseMenu.SetActive(true);
        _time.SetActive(false);
        _place.SetActive(false);

        Time.timeScale = 0f;
        Cursor.visible = true;
    }
    void Inventory(InputAction.CallbackContext context)
    {
        PlayerControlls.Player.Disable();
        PlayerControlls.UI.Enable();
        _inventoryUI.SetActive(true);
        _time.SetActive(false);
        _place.SetActive(false);

        Time.timeScale = 0f;
        Cursor.visible = true;
    }
    void Back(InputAction.CallbackContext context)
    {
        PlayerControlls.Player.Enable();
        PlayerControlls.UI.Disable();

        _pauseMenu.SetActive(false);
        _inventoryUI.SetActive(false);
        _time.SetActive(true);
        _place.SetActive(true);

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
        transform.rotation = Quaternion.RotateTowards(transform.rotation, appliedRotation, _turnSmoothVelocity * Time.deltaTime);
    }
    void CameraMovement()
    {
        _camera.transform.position = transform.position;
    }
    bool IsPlayerMoving()
    {
        return _move.ReadValue<Vector2>().magnitude > .05f;
    }
}


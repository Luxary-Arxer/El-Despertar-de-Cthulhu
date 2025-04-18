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

    Vector3 _movementInput;

    CharacterController _characterController;

    GameObject _interactableObject;

    [SerializeField]
    float _characterSpeed;
    [SerializeField]
    float _turnSmoothVelocity;

    [SerializeField]
    GameObject _pauseMenu;

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

        _move.Enable();
        _pause.Enable();
        _interact.Enable();
        _inventory.Enable();

        _pause.performed += Pause;
        _interact.performed += Interact;
        _inventory.performed += Inventory;
    }
    void OnDisable()
    {
        _move.Disable();
        _pause.Disable();
        _interact.Disable();
        _inventory.Disable();
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
    private void Pause(InputAction.CallbackContext context)
    {
        PlayerControlls.Player.Disable();
        PlayerControlls.UI.Enable();
        _pauseMenu.SetActive(true);

        Time.timeScale = 0f;
        Cursor.visible = true;
    }
    private void Interact(InputAction.CallbackContext context)
    {
        string tag = _interactableObject.tag;

        switch (tag)
        {
            case "Exit":
                //ExitInteraction();
                break;
            case "Item":
                //ItemPickUp();
                break;
            case "NPC":
                //TalkInteraction();
                break;
        }
    }
    private void Inventory(InputAction.CallbackContext context)
    {
        Debug.Log("Has abierto el inventario!");
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


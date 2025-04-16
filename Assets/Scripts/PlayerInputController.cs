using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField]
    Transform _camera;
    public PlayerControllsDefault PlayerControlls;
    InputAction _move;
    //InputAction _pause;
    InputAction _interact;
    //InputAction _jump;
    Vector3 _movementInput;
    CharacterController _characterController;
    [SerializeField]
    float _characterSpeed;
    [SerializeField]
    float _turnSmoothVelocity;

    void Awake()
    {
        PlayerControlls = new PlayerControllsDefault();
        _characterController = GetComponent<CharacterController>();

        Cursor.visible = false;
    }
    void OnEnable()
    {
        _move = PlayerControlls.Player.Move;
        //_pause = PlayerControlls.Player.Pause;
        _interact = PlayerControlls.Player.Interact;
        //_jump = PlayerControlls.Player.Jump;

        _move.Enable();
        //_pause.Enable();
        _interact.Enable();
        //_jump.Enable();

        //_pause.performed += Pause;
        _interact.performed += Interact;
        //_jump.performed += Jump;
    }
    void OnDisable()
    {
        _move.Disable();
        //_pause.Disable();
        _interact.Disable();
    }

    void Update()
    {
        GatherInput();

        if (_move.ReadValue<Vector2>().magnitude > .05f)
        {
            CharacterMovement();
            CharacterRotation();

            CameraMovement();
        }

    }
    // private void Pause(InputAction.CallbackContext context)
    // {
    //     PlayerControlls.Player.Disable();
    //     PlayerControlls.UI.Enable();
    //     _pauseMenu.SetActive(true);

    //     Time.timeScale = 0f;
    //     Cursor.visible = true;
    // }
    private void Interact(InputAction.CallbackContext context)
    {
        string tag = "" /*_interactableObject.tag*/;
        switch (tag)
        {//lo hago con switch por si en el futuro el numero de interacciones sube más.
            case "Chest":
                //ChestInteraction();
                break;
            case "Item":
                //ItemPickUp();
                break;
        }
    }
    void GatherInput()
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
}


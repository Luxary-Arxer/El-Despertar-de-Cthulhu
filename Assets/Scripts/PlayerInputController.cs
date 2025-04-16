using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using Unity.VisualScripting;

public class PlayerInputController : MonoBehaviour
{
    //[SerializeField]
    //GameObject _pauseMenu;
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
    float _turnSmoothVelocity = 1440;
    //[SerializeField]
    //GameObject[] _itemSlots;
    //public List<Item> Inventory = new();
    Collider _interactableObject;

    // public class Item
    // {
    //     public SpriteRenderer InventoryImage;
    //     public Item(SpriteRenderer img)
    //     {
    //         InventoryImage = img;
    //     }
    // }
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
        if (_interactableObject != null)
        {
            string tag = _interactableObject.tag;
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
    }
    // void ChestInteraction()
    // {
    //     ChestRandomAlgorithm chest = _interactableObject.GetComponentInParent<ChestRandomAlgorithm>();
    //     chest.OnChestOpen();
    // }
    // void ItemPickUp()
    // {
    //     //if (Inventory.Count < _itemSlots.Length)
    //     //{
    //     CollectibleItemLogic pickedItem = _interactableObject.GetComponent<CollectibleItemLogic>();
    //     //Item newInventoryItem = new(pickedItem.Image);
    //     //Inventory.Add(newInventoryItem);
    //     pickedItem.OnItemPicked();
    //     //RefreshInventoryUI();
    //     //}
    //     //else
    //     //{
    //     Debug.Log("Objeto recogido");
    //     //}
    // }
    /*void RefreshInventoryUI()
    {
        for (int i = 0; i < _itemSlots.Length && i < Inventory.Count; i++)
        {
            Image img = _itemSlots[i].GetComponent<Image>();
            img.sprite = Inventory[i].InventoryImage.sprite;
            Color imgColor = img.color;
            imgColor.a = 255;
            img.color = imgColor;
        }
    }*/
    // void OnTriggerEnter(Collider collider)
    // {
    //     _interactableObject = collider;
    // }
    // public void RebindInteract(InputAction interactKeyCode)
    // {
    //     _interactRebind = interactKeyCode.PerformInteractiveRebinding().Start();
    //     _interactRebind.Dispose();
    // }
    void GatherInput()
    {
        Vector2 inputVector = _move.ReadValue<Vector2>();
        _movementInput = new(inputVector.x, 0, inputVector.y);
    }
    void CharacterMovement()
    {
        _characterController.Move(_characterSpeed * Time.deltaTime * (transform.forward * _movementInput.magnitude));
    }
    void CharacterRotation()
    {
        var realtiveRotationAngle = transform.position + _movementInput - transform.position;
        var appliedRotation = Quaternion.LookRotation(realtiveRotationAngle, Vector3.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, appliedRotation, _turnSmoothVelocity * Time.deltaTime);
    }
}


using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
	[Header("Character Input Values")]
	public Vector2 move;
	public Vector2 look;
	public Vector2 cursor;
	public bool jump;
	public bool sprint;
	public bool interact;
	public bool inventory;
	private bool mute = false;

	[Header("Mouse Cursor Settings")]
	public bool cursorLocked = true;
	public bool cursorInputForLook = true;

	public PlayerControls playerControls;

	private void Awake()
    {
		playerControls = new PlayerControls();
	}

    private void OnEnable()
    {
		playerControls.Enable();

		playerControls.Player.Move.started += OnMove;
		playerControls.Player.Move.canceled += OnMove;
		playerControls.Player.Move.performed += OnMove;

		playerControls.Player.Look.started += OnLook;
		playerControls.Player.Look.canceled += OnLook;
		playerControls.Player.Look.performed += OnLook;

		playerControls.Player.Jump.performed += OnJump;

		playerControls.Player.Sprint.performed += OnSprint;

		playerControls.Player.Interact.performed += OnInteract;

		playerControls.Player.Inventory.performed += OnInventory;

		playerControls.Player.Mute.performed += OnMute;
	}


    private void OnDisable()
    {
		playerControls.Disable();

		playerControls.Player.Move.started -= OnMove;
		playerControls.Player.Move.canceled -= OnMove;
		playerControls.Player.Move.performed -= OnMove;

		playerControls.Player.Look.started -= OnLook;
		playerControls.Player.Look.canceled -= OnLook;
		playerControls.Player.Look.performed -= OnLook;

		playerControls.Player.Jump.performed -= OnJump;

		playerControls.Player.Sprint.performed -= OnSprint;

		playerControls.Player.Interact.performed -= OnInteract;

		playerControls.Player.Inventory.performed -= OnInventory;

		playerControls.Player.Mute.performed -= OnMute;
	}

    public void OnMove(InputAction.CallbackContext context)
	{
		move = context.ReadValue<Vector2>();
	}

	public void OnLook(InputAction.CallbackContext context)
	{
		if (cursorInputForLook)
		{
			look = context.ReadValue<Vector2>();
		}
	}

	public void OnJump(InputAction.CallbackContext context)
	{
		jump = context.ReadValueAsButton();
	}

	public void OnSprint(InputAction.CallbackContext context)
	{
		sprint = context.ReadValueAsButton();
	}

	public void OnInteract(InputAction.CallbackContext context)
	{
		interact = context.ReadValueAsButton();
	}
	public void OnInventory(InputAction.CallbackContext context)
	{
		inventory = context.ReadValueAsButton();
	}
	public void OnMute(InputAction.CallbackContext context)
	{
		mute = !mute;
		AudioListener.volume = mute ? 0f : 1f;
	}


}
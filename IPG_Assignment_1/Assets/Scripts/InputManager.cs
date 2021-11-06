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

	[Header("Mouse Cursor Settings")]
	public bool cursorLocked = true;
	public bool cursorInputForLook = true;

	private PlayerControls playerControls;

	public delegate void StartInteract(float time);
	public event StartInteract OnStartInteract;
	public delegate void EndInteract(float time);
	public event EndInteract OnEndInteract;


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

		playerControls.Player.Interact.started += StartInteraction;
		playerControls.Player.Interact.canceled += EndInteraction;

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

		playerControls.Player.Interact.started -= StartInteraction;
		playerControls.Player.Interact.canceled -= EndInteraction;

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

	public void StartInteraction(InputAction.CallbackContext context)
	{
		if (OnStartInteract != null)
		{
			OnStartInteract((float)context.startTime);
		}
	}

	public void EndInteraction(InputAction.CallbackContext context)
	{
		if (OnEndInteract != null)
		{
			OnEndInteract((float)context.time);
		}
	}

}
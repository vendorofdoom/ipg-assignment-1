using UnityEngine;
using UnityEngine.InputSystem;

// Brackeys RPG tutorial: https://youtu.be/9tePzyL6dgc
// Interactable tutorial: https://youtu.be/858X6_WHfuw

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance;
    public TMPro.TextMeshProUGUI Text;
    public Camera cam;

    public InputManager inputManager;

    private Interactable interactable;
    private bool successfulHit = false;


    //private void Awake()
    //{
    //    inputManager = GetComponent<InputManager>();
    //}

    private void OnEnable()
    {
        inputManager.playerControls.Player.Interact.started += StartInteract;
        inputManager.playerControls.Player.Interact.canceled += EndInteract;
    }

    private void OnDisable()
    {
        inputManager.playerControls.Player.Interact.started -= StartInteract;
        inputManager.playerControls.Player.Interact.canceled -= EndInteract;
    }

    private void Update()
    {
        Vector2 cursorPos = Mouse.current.position.ReadValue();

        Ray ray = cam.ScreenPointToRay(cursorPos);
        RaycastHit hit;
        successfulHit = false;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {

            interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                Text.text = interactable.GetDescription();
                successfulHit = true;
            }
        }

        if (!successfulHit)
        {
            Text.text = "";
        }
    }

    private void StartInteract(InputAction.CallbackContext context)
    {
        // leaving this here in case I want to implement some kind of press and hold functionality
    }

    private void EndInteract(InputAction.CallbackContext context)
    {
        if (successfulHit && interactable != null)
        {
            interactable.Interact();
        }
    }

}

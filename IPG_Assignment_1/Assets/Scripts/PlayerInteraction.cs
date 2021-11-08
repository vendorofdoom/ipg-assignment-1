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

    public float timeout = 0.2f;
    private float _timeout;

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

                if (inputManager.interact && _timeout <= 0.0f)
                {
                    interactable.Interact();
                    _timeout = timeout;
                    inputManager.interact = false;
                }

            }
        }

        _timeout = Mathf.Clamp(_timeout - Time.deltaTime, -1f, timeout + 1f);

        if (!successfulHit)
        {
            Text.text = "";
        }
    }

}

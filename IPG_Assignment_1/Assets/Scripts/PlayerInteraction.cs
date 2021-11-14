using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

// Brackeys RPG tutorial: https://youtu.be/9tePzyL6dgc
// Interactable tutorial: https://youtu.be/858X6_WHfuw

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance;
    public TextMeshProUGUI text;
    public Camera cam;
    private int layerMask;

    public InputManager inputManager;

    private Interactable interactable;

    public float timeout = 0.2f;
    private float _timeout;

    private Transform player;

    private void Awake()
    {
        layerMask = 1 << 6; // interactable layer
    }

    private void Update()
    {
        text.text = "";

        Ray ray = new Ray(transform.position, transform.forward);
        foreach (RaycastHit hit in Physics.SphereCastAll(ray, interactionDistance, interactionDistance, layerMask))
        {

            interactable = hit.collider.GetComponent<Interactable>();

            if (interactable != null)
            {
                text.text = interactable.GetDescription();

                if (inputManager.interact && _timeout <= 0.0f)
                {
                    interactable.Interact();
                    _timeout = timeout;
                }

            }
        }

        _timeout = Mathf.Clamp(_timeout - Time.deltaTime, -1f, timeout + 1f);

        inputManager.interact = false;
    }
}

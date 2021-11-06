using UnityEngine;

// Brackeys RPG tutorial: https://youtu.be/9tePzyL6dgc
// Interactable tutorial: https://youtu.be/858X6_WHfuw

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance;
    public TMPro.TextMeshProUGUI Text;
    public Camera cam;


    private void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        bool succesfulHit = false;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {

            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                Text.text = interactable.GetDescription();
                succesfulHit = true;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                }
                
            }
        }

        if (!succesfulHit)
        {
            Text.text = "";
        }

    }

}

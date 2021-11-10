using UnityEngine;
using TMPro;

public class Home : MonoBehaviour
{
    public BoxCollider door;
    public TextMeshProUGUI text;

    private bool doorLocked = false;
    private bool displayMessage = false;

    public Opening opening;
    public Ending ending;

    private void Awake()
    {
        if (opening != null)
        {
            opening.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (opening.enabled)
            {
                displayMessage = false;
            }

            else
            {
                if (doorLocked)
                {
                    displayMessage = true;
                } else
                {
                    displayMessage = false;
                    if (ending != null)
                    {
                        ending.enabled = true;
                    }
                }
            }

        }
    }

    private void Update()
    {
        if (doorLocked && displayMessage)
        {
            text.text = "My inner balance is still off... I should get back to the garden and finish what I was doing.";
        } 
    }

    private void OnTriggerExit(Collider other)
    {

        // when the player leaves home, lock the door until they complete the tasks
        if (other.CompareTag("Player") && !doorLocked)
        {
            LockDoor();
        } 

        displayMessage = false;
        text.text = "";
    }

    public void LockDoor()
    {
        door.isTrigger = false;
        doorLocked = true;
    }

    public void unlockDoor()
    {
        door.isTrigger = true;
        doorLocked = false;
    }

}

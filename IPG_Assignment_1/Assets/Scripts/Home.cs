using UnityEngine;
using TMPro;

public class Home : MonoBehaviour
{
    public BoxCollider door;
    public TextMeshProUGUI text;

    [SerializeField]
    private bool doorLocked = false;
    [SerializeField]
    private bool displayMessage = false;

    [Header("Cutscenes")]
    public Opening opening;
    public Ending ending;

    private void Awake()
    {
        //opening.enabled = true;
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
                    //ending.enabled = true; 
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

using UnityEngine;
using TMPro;

public class Home : MonoBehaviour
{
    public BoxCollider door;
    public TextMeshProUGUI text;
    public GameManager gm;

    private bool displayMessage = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gm.tasksComplete)
            {
                door.isTrigger = true;
                displayMessage = false;
                gm.EndGame();
            } else
            {
                displayMessage = true;
            }
        }
    }

    private void Update()
    {
        if (!door.isTrigger && displayMessage)
        {
            text.text = "My inner balance is still off... I should get back to the garden and finish what I was doing.";
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !gm.tasksComplete)
        {
            door.isTrigger = false; // i.e. lock the door
        } 

        displayMessage = false;
        text.text = "";
    }
}

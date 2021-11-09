using UnityEngine;
using StarterAssets;

// Brackeys tutorial: https://youtu.be/VbZ9_C4-Qbo

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public TMPro.TextMeshProUGUI Text;

    public float resetDelay= 1.5f;
    public bool resetPlayer = false;

    private float fontSize;

    private InputManager input;

    public Opening openScene;

    public bool tasksComplete = false;

    private void Start()
    {
        input = Player.GetComponent<InputManager>();
        fontSize = Text.fontSize;
        openScene.enabled = true;
    }

    public void ResetPlayer()
    {
        if (resetPlayer == false)
        {
            resetPlayer = true;
            Player.SetActive(false);
            Text.fontSize = fontSize * 2;
            Text.text = "SPLASH!";
            Invoke("ResetPlayerPosition", resetDelay);
        }
    }

    public void ResetPlayerPosition()
    {
        Player.transform.position = new Vector3(0f, 0f, 0f); // TODO: replace with last known land position
        input.move = new Vector2(0f, 0f); // stop movement

        resetPlayer = false;
        Player.SetActive(true);
        
        Text.fontSize = fontSize;
        Text.text = "";
    }

    public void TasksComplete()
    {
        tasksComplete = true;
    }

    public void EndGame()
    {
        Debug.Log("Game complete!");
    }
}

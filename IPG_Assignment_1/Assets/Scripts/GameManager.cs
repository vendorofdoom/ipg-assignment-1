using UnityEngine;
using StarterAssets;

// Brackeys tutorial: https://youtu.be/VbZ9_C4-Qbo

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public TMPro.TextMeshProUGUI Text;

    public float resetDelay= 1.5f;
    public bool resetPlayer = false;

    private InputManager input;

    private void Start()
    {
        input = Player.GetComponent<InputManager>();
    }

        public void ResetPlayer()
    {
        if (resetPlayer == false)
        {
            resetPlayer = true;
            Player.SetActive(false);
            Text.fontSize = 36f;
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
        
        Text.fontSize = 12f;
        Text.text = "";
    }
}

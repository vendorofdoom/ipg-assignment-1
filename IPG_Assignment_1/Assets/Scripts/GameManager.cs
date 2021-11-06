using UnityEngine;

// Brackeys tutorial: https://youtu.be/VbZ9_C4-Qbo

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public TMPro.TextMeshProUGUI Text;

    public float resetDelay= 1f;
    public bool resetPlayer = false;

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
        Player.transform.position = new Vector3(0f, 0f, 0f);
        Player.SetActive(true);
        resetPlayer = false;
        Text.fontSize = 12f;
        Text.text = "";
    }
}

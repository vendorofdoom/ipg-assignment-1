using UnityEngine;
using TMPro;
using System.Collections;

public class Water : MonoBehaviour
{
    private float fontSize;

    private bool playerFellInWater = false;
    private float timeInWater;

    private GameObject player;
    private InputManager input;
    private CanvasGroup backgroundImage;
    private TextMeshProUGUI text;
    
    private bool playerPosHasBeenReset = false;

    private void Awake()
    {
        text = GameObject.Find("Canvas/Info").GetComponent<TextMeshProUGUI>();
        backgroundImage = GameObject.Find("Canvas/Background").GetComponent<CanvasGroup>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            input = player.GetComponent<InputManager>();
            player.SetActive(false);
            playerFellInWater = true;
            playerPosHasBeenReset = false;
            timeInWater = 0f;
            fontSize = text.fontSize;
            text.fontSize = fontSize * 2;
        }
    }

    private void Update()
    {
        if (playerFellInWater)
        {
            if (timeInWater <= 2f)
            {
                text.text = "SPLASH!\nI'd better go dry off...";
                backgroundImage.alpha += Time.deltaTime / 2f;
            }
            else if (timeInWater > 2f && timeInWater <= 3f)
            {
                text.alpha -= Time.deltaTime / 1f;
            }
            else if (timeInWater > 3f && timeInWater <= 3.5f)
            {
                if (!playerPosHasBeenReset)
                {
                    player.transform.position = new Vector3(-12f, 0f, 0.5f);
                    input.move = new Vector2(0f, 0f);
                    player.SetActive(true);
                    input.enabled = false;
                    playerPosHasBeenReset = true;
                    text.fontSize = fontSize;
                    text.text = "";
                    text.alpha = 255f;

                }
                backgroundImage.alpha -= Time.deltaTime / 0.5f;
            }
            else
            {
                playerFellInWater = false;
                input.enabled = true;
                backgroundImage.alpha = 0f;
            }

            timeInWater += Time.deltaTime;

        }
    }

}

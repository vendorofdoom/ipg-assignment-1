using UnityEngine;
using TMPro;

public class Water : MonoBehaviour
{
    private GameObject player;
    private CanvasGroup backgroundImage;
    private TextMeshProUGUI message;
    private bool playerFellInWater = false;

    [Header ("Animation timing")]
    public float fadeInTime = 1f;
    private float elapsedTime;

    private void Awake()
    {
        message = GameObject.Find("Canvas/Water").GetComponent<TextMeshProUGUI>();
        backgroundImage = GameObject.Find("Canvas/Background").GetComponent<CanvasGroup>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerFellInWater = true;
            elapsedTime = 0f;

            player = other.gameObject;
            player.GetComponent<StarterAssets.ThirdPersonController>().enabled = false;
            player.GetComponent<CharacterController>().enabled = false;
            GameObject.Find("PlayerCapsule/Capsule").GetComponent<MeshRenderer>().enabled = false;
            GameObject.Find("PlayerCapsule/Face").GetComponent<MeshRenderer>().enabled = false;
        }
    }


    // TODO: consider if there's going to be issues where I have multiple water sections and player falls at a seam triggering two? 

    private void Update()
    {
        if (playerFellInWater)
        {
            if (elapsedTime <= fadeInTime)
            {
                message.text = "SPLASH!\nI'd better go dry off...";
                backgroundImage.alpha += Time.deltaTime / fadeInTime;
            }

            else
            {
                player.transform.position = new Vector3(0f, 0f, 0f);
                player.GetComponent<CharacterController>().enabled = true;
                player.GetComponent<StarterAssets.ThirdPersonController>().enabled = true;
                GameObject.Find("PlayerCapsule/Capsule").GetComponent<MeshRenderer>().enabled = true;
                GameObject.Find("PlayerCapsule/Face").GetComponent<MeshRenderer>().enabled = true;
                player.GetComponent<InputManager>().move = new Vector2(0f, 0f);
                playerFellInWater = false;
                backgroundImage.alpha = 0f;
                message.text = "";
            }

            elapsedTime += Time.deltaTime;

        }
    }

}

using UnityEngine;
using TMPro;

public class Water : MonoBehaviour
{
    private GameObject player;
    private CanvasGroup backgroundImage;
    private TextMeshProUGUI message;
    private TextMeshProUGUI info;
    private bool playerFellInWater = false;

    [Header("Audio")]
    public AudioClip splashClip;
    private AudioSource splashSource;


    [Header ("Animation timing")]
    public float fadeInTime = 1f;
    private float elapsedTime;


    private void Awake()
    {
        info = GameObject.Find("Canvas/Water").GetComponent<TextMeshProUGUI>();
        message = GameObject.Find("Canvas/Info").GetComponent<TextMeshProUGUI>();
        backgroundImage = GameObject.Find("Canvas/Background").GetComponent<CanvasGroup>();
        splashSource = GameObject.Find("PlayerCapsule").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerFellInWater = true;
            elapsedTime = 0f;
            player = other.gameObject;
            StopPlayer();
            splashSource.PlayOneShot(splashClip);
        }
    }

    // TODO: consider if there's going to be issues where I have multiple water sections and player falls at a seam triggering two? 
    private void Update()
    {
        if (playerFellInWater)
        {
            if (elapsedTime <= fadeInTime)
            {
                info.text = "";
                message.text = "Oops! I better go dry off...";
                backgroundImage.alpha += Time.deltaTime / fadeInTime;
            }
            else
            {
                player.transform.position = new Vector3(-12f, 0f, -2f);
                StartPlayer();
                playerFellInWater = false;
                backgroundImage.alpha = 0f;
                message.text = "";
            }
            elapsedTime += Time.deltaTime;
        }
    }

    private void StopPlayer()
    {
        player.GetComponent<Inventory>().UnequipCurrentItem();
        player.GetComponent<StarterAssets.ThirdPersonController>().enabled = false;
        player.GetComponent<PlayerInteraction>().enabled = false;
        player.GetComponent<CharacterController>().enabled = false;
        GameObject.Find("PlayerCapsule/Capsule").GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("PlayerCapsule/Face").GetComponent<MeshRenderer>().enabled = false;
    }

    private void StartPlayer()
    {
        player.GetComponent<CharacterController>().enabled = true;
        player.GetComponent<PlayerInteraction>().enabled = true;
        player.GetComponent<StarterAssets.ThirdPersonController>().enabled = true;
        GameObject.Find("PlayerCapsule/Capsule").GetComponent<MeshRenderer>().enabled = true;
        GameObject.Find("PlayerCapsule/Face").GetComponent<MeshRenderer>().enabled = true;
        player.GetComponent<InputManager>().move = new Vector2(0f, 0f);
    }
}

using UnityEngine;

public class Water : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().ResetPlayer();
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene("garden");
    }
}

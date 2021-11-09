using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public TextMeshProUGUI text;
    public InputManager input;
    public CanvasGroup endScreen;

    private void Awake()
    {
        input.enabled = false;
    }

    IEnumerator Start()
    {

        yield return new WaitForSeconds(2f);

        text.text = "Ahh much better...";

        yield return new WaitForSeconds(2f);

        text.text = "The garden is tidy...";

        yield return new WaitForSeconds(3f);

        text.text = "The koi are fed...";

        yield return new WaitForSeconds(2f);
        
        text.text = "Inner balance restored.";

        text.CrossFadeAlpha(0f, 5f, false);
        // endScreen.CrossFadeAlpha(255f, 2f, true); // TODO: why won't this work in coroutine!?!?

        yield return new WaitForSeconds(5f);

        text.text = "";

        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        endScreen.alpha += Time.deltaTime / 5f; // https://community.gamedev.tv/t/canvasgroup-for-fading/13172/6
    }
}

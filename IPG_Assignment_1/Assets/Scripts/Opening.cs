using UnityEngine;
using TMPro;
using System.Collections;

// Alan's video: https://youtu.be/_Oi6MuesXnw

public class Opening : MonoBehaviour
{
    public TextMeshProUGUI text;
    public InputManager input;
    public ParticleSystem rain; // rain effect tutorial: https://youtu.be/xkB6yzCBfgw
    public Home home;

    private void Awake()
    {
        rain.Play(true);
        input.enabled = false;
    }

    IEnumerator Start()
    {

        yield return new WaitForSeconds(2f);

        text.text = "What a crazy storm last night...";

        yield return new WaitForSeconds(2f);

        text.text = "The garden is a mess...";

        yield return new WaitForSeconds(2f);

        text.text = "My inner balance is all off...";

        yield return new WaitForSeconds(3f);

        text.text = "...";

        yield return new WaitForSeconds(1f);

        text.text = "I'd better get outside, the koi fish need their breakfast.";

        yield return new WaitForSeconds(3f);

        text.text = "";
        input.enabled = true;
        home.enabled = true;
        rain.Stop();
        this.enabled = false;

    }

}



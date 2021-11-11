using UnityEngine;
using TMPro;
using System.Collections;

// Alan's video: https://youtu.be/_Oi6MuesXnw

public class Opening : MonoBehaviour
{
    public TextMeshProUGUI text;
    public InputManager input;
    public ParticleSystem rain; // rain effect tutorial: https://youtu.be/xkB6yzCBfgw

    IEnumerator Start()
    {
        rain.Play();
        input.enabled = false;

        yield return new WaitForSeconds(1f);

        text.text = "What a crazy storm last night...";

        yield return new WaitForSeconds(2f);

        text.text = "The garden is a mess...";

        yield return new WaitForSeconds(2f);

        text.text = "My inner balance is all off...";

        yield return new WaitForSeconds(3f);

        text.text = "I should get outside and give the koi fish their breakfast.";

        yield return new WaitForSeconds(3f);

        text.text = "";
        input.enabled = true;
        rain.Stop();
        this.enabled = false;

    }

}



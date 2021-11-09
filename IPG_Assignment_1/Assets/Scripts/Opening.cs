using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;

// Alan's video: https://youtu.be/_Oi6MuesXnw

public class Opening : MonoBehaviour
{
    public TextMeshProUGUI text;
    public InputManager input;
    public ParticleSystem rain;
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

        text.text = "The garden is a mess and my inner balance is all off...";

        yield return new WaitForSeconds(3f);

        text.text = "I'd better get outside, the koi fish need their breakfast.";

        yield return new WaitForSeconds(2f);

        text.text = "";
        input.enabled = true;
        home.enabled = true;
        rain.Stop();
        this.enabled = false;

    }

}



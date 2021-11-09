using UnityEngine;
using TMPro;

public class Opening : MonoBehaviour
{
    public float text1 = 2f;
    public float text2 = 4f;
    public float text3 = 6f;

    private float start;

    public TextMeshProUGUI text;
    public InputManager input;
    public ParticleSystem rain;
    public BoxCollider door;

    private void Start()
    {
        start = Time.time;
        door.isTrigger = false;
        rain.Play(true);
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time - start <= text1)
        {
            input.enabled = false;
            text.text = "What a storm last night...";
        }

        else if (text1 < Time.time - start && Time.time - start <= text2)
        {
            text.text = "Looks like it's finally clearing up but the garden is a mess and my inner balance is all off.";
        }

        else if (text2 < Time.time - start && Time.time - start <= text3)
        {
            text.text = "I better get outside, the koi fish will want their breakfast.";
        }

        else
        {
            text.text = "";
            input.enabled = true;
            this.enabled = false;
            door.isTrigger = true;
            rain.Stop();
        }
    }
}

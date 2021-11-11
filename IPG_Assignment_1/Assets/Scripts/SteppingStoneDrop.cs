using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteppingStoneDrop : MonoBehaviour
{
    public Vector3 stoneUpPos;
    public Vector3 stoneDownPos;

    private float timeStart;
    public float timeDown = 0.2f;
    public float timeUp = 1f;

    private bool doTheLerp = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!doTheLerp)
            {
                timeStart = Time.time;
                doTheLerp = true;
            }
        }
    }


    private void Update()
    {
        if (doTheLerp)
        {
            float elapsedTime = (Time.time - timeStart);
            if (elapsedTime <= timeDown)
            {
                float t = elapsedTime / timeDown;
                transform.position = Vector3.Lerp(stoneUpPos, stoneDownPos, t);
            }
            else
            {
                float t = (elapsedTime - timeDown) / timeUp;
                transform.position = Vector3.Lerp(stoneDownPos, stoneUpPos, t);
            }

            if (elapsedTime > (timeDown + timeUp))
            {
                doTheLerp = false;
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rakeable : MonoBehaviour
{
    private bool canRake = false;
    private Transform player;
    private GameObject rake;
    private Vector2 stationery = new Vector2(0f, 0f);
    private Task task;

    [Header("Rake task timings")]
    [SerializeField]
    private float timeSpentRaking = 0f;
    public float rakingTimeRequired = 5f;

    [Header("Audio")]
    public AudioSource rakingAudio;

    private void Awake()
    {
        task = GetComponent<Task>();   
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == true)
        {
            player = other.transform;
            rake = player.Find("Rake").gameObject;
            canRake = true;
            rakingAudio.enabled = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") == true)
        {
            canRake = false;
            rakingAudio.enabled = false;
            player.Find("RakeTrailSource").GetComponent<TrailRenderer>().emitting = false;
        }

    }

    private void Update()
    {
        if (canRake)
        {
            player.Find("RakeTrailSource").GetComponent<TrailRenderer>().emitting = rake.activeSelf;

            if (player.GetComponent<InputManager>().move != stationery && rake.activeSelf)
            {
                timeSpentRaking += Time.deltaTime;
                rakingAudio.UnPause();
            }
            else
            {
                rakingAudio.Pause();
            }


            if (timeSpentRaking > rakingTimeRequired && !task.isComplete)
            {
                task.Complete();
            }
        }

    }
}

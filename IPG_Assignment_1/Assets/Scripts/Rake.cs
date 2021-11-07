using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rake : MonoBehaviour
{
    private bool canRake = false;
    private Transform player;
    private GameObject rake;

    private Vector2 stationery = new Vector2(0f, 0f);

    [SerializeField]
    private float timeSpentRaking = 0f;

    public float rakingTimeRequired = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == true)
        {
            player = other.transform;
            rake = player.Find("Rake").gameObject;
            canRake = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") == true)
        {
            canRake = false;
        }

    }

    private void Update()
    {
        if (player != null) {
            player.Find("RakeTrailSource").GetComponent<TrailRenderer>().emitting = canRake && rake.activeSelf;
            if (player.GetComponent<InputManager>().move != stationery && canRake && rake.activeSelf)
            {
                timeSpentRaking += Time.deltaTime;
            }
            
        }

        if (timeSpentRaking > rakingTimeRequired)
        {
            GetComponent<Task>().isComplete = true;
        }

    }
}

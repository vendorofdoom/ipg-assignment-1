using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rakeable : MonoBehaviour
{
    private bool canRake = false;
    private Transform player;
    private GameObject rake;

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
        }

    }
}

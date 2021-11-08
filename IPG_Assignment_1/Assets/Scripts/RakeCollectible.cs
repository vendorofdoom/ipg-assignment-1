using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RakeCollectible : MonoBehaviour
{
    public Task branches1;
    public Task branches2;
    public Task branches3;

    public GameObject rake;

    private void Update()
    {
        if (branches1.isComplete && branches2.isComplete && branches3.isComplete)
        {
            rake.SetActive(true);
            this.enabled = false;
        }
    }

}

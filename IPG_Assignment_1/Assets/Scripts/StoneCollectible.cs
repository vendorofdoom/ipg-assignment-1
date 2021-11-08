using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCollectible : MonoBehaviour
{
    public Task rakeGarden;

    public GameObject steppingStone;

    private void Update()
    {
        if (rakeGarden.isComplete)
        {
            steppingStone.SetActive(true);
            this.enabled = false;
        }
    }

}

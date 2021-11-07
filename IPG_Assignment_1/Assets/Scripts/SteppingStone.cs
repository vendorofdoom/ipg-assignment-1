using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteppingStone : Interactable
{
    public GameObject brokenStone;
    public GameObject fixedStone;
    public Inventory inventory;

    public Vector3 stoneUpPos;
    public Vector3 stoneDownPos;

    private bool isFixed = false;

    private float timeStart;
    public float timeDown = 0.2f;
    public float timeUp = 1f;

    private bool doTheLerp = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isFixed && !doTheLerp)
        {
            timeStart = Time.time;
            doTheLerp = true;
        }
    }

    public override string GetDescription()
    {
        if (isFixed)
        {
            return "Nice and stable :)";
        } else
        {
            if (inventory.isStoneEquipped())
            {
                return "Press E to fix the broken stepping stone";
                // TODO: remove stone from inventory
            } else
            {
                return "Hm... that doesn't look very stable, maybe there's another stone I can repair it with?";
            }
        }
    }

    public override void Interact()
    {
        if (!isFixed && inventory.isStoneEquipped())
        {
            inventory.useStone();
            brokenStone.SetActive(false);
            fixedStone.SetActive(true);
            isFixed = true;
            GetComponent<Task>().isComplete = true;
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
                brokenStone.transform.position = Vector3.Lerp(stoneUpPos, stoneDownPos, t);
            } else
            {
                float t = (elapsedTime - timeDown) / timeUp;
                brokenStone.transform.position = Vector3.Lerp(stoneDownPos, stoneUpPos, t);
            }

            if (elapsedTime > (timeDown + timeUp))
            {
                doTheLerp = false;
            }
        }
    }

}
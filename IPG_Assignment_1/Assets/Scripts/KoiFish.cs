using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoiFish : Interactable
{

    public Inventory inventory;
    private bool koiFed = false;

    public float feedTime = 3f;
    private float startTime;
    public float containerDelay = 0.5f;

    private bool sprinkleFood = false;
    public ParticleSystem fishFood;
    public GameObject fishFoodContainer;


    public override string GetDescription()
    {
        if (!koiFed)
        {
            if (inventory.isFishFoodEquipped())
            {
                return "Press E to feed the fish!";
            }
            else
            {
                return "I should fed them...";
            }

        } else
        {
            return "Happy fish :) don't they get dizzy swimming in circles like that?";
        }
    }

    public override void Interact()
    {
        if (!koiFed && inventory.isFishFoodEquipped())
        {
            inventory.useFishFood();
            koiFed = true;
            GetComponent<Task>().isComplete = true;
            startTime = Time.time;
            sprinkleFood = true;
            fishFood.Play();
            fishFoodContainer.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (sprinkleFood)
        {
            if (Time.time - startTime >= feedTime)
            {
                fishFood.Stop();
            }

            if (Time.time - startTime >= feedTime + containerDelay)
            {
                sprinkleFood = false;
                fishFoodContainer.SetActive(false);
            }
        }
        
    }
}

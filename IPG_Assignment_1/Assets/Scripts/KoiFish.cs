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
            if (inventory.IsEquipped(Inventory.InventoryItem.FishFood))
            {
                return "Press [E] to feed the fish!";
            }
            else
            {
                return "Waiting for their breakfast...";
            }

        } else
        {
            return "Don't they get dizzy swimming in circles like that? I should get home and feed myself!";
        }
    }

    public override void Interact()
    {
        if (!koiFed && inventory.IsEquipped(Inventory.InventoryItem.FishFood))
        {
            inventory.UseItem(Inventory.InventoryItem.FishFood);
            koiFed = true;
            GetComponent<Task>().Complete();
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

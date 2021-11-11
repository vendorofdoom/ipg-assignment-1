using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteppingStone : Interactable
{
    public GameObject brokenStone;
    public GameObject fixedStone;
    public Inventory inventory;

    private bool isFixed = false;

    public override string GetDescription()
    {
        if (isFixed)
        {
            return "Strong and stable";
        } else
        {
            if (inventory.IsEquipped(Inventory.InventoryItem.SteppingStone))
            {
                return "Press [E] to fix the broken stepping stone";
            } else
            {
                return "Hm... that doesn't look very stable...";
            }
        }
    }

    public override void Interact()
    {
        if (!isFixed && inventory.IsEquipped(Inventory.InventoryItem.SteppingStone))
        {
            inventory.UseItem(Inventory.InventoryItem.SteppingStone);
            brokenStone.SetActive(false);
            fixedStone.SetActive(true);
            isFixed = true;
            GetComponent<Task>().Complete();
        }
    }



}

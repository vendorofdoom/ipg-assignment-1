using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : Interactable
{
    public Inventory inventory;
    public Inventory.InventoryItem item;
    public string message;

    public override string GetDescription()
    {
        return message;
    }

    public override void Interact()
    {
        inventory.Add(item);
        gameObject.SetActive(false);
    }

}

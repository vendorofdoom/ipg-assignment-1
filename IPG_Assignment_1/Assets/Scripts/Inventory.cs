using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// TODO: not sure about enum + case statements, try with dict later?

public class Inventory : MonoBehaviour
{
    public GameObject rake;
    public GameObject fishFood;
    public GameObject steppingStone;

    public InputManager inputManager;
    private List<GameObject> inventoryItems;
    private GameObject equippedItem;
    
    public enum InventoryItem
    {
        Rake,
        FishFood,
        SteppingStone
    }

    private void Awake()
    {
        inventoryItems = new List<GameObject>();
        AddToInventory(null);
        AddToInventory(rake);
        AddToInventory(steppingStone);
        AddToInventory(fishFood);
    }

    private void OnEnable()
    {
        inputManager.playerControls.Player.Inventory.started += OnInventory;
    }

    private void OnDisable()
    {
        inputManager.playerControls.Player.Inventory.started -= OnInventory;
    }

    private void AddToInventory(GameObject item)
    {
        inventoryItems.Add(item);
    }

    private void RemoveFromInventory(GameObject item)
    {

        if (equippedItem == item)
        {
            equippedItem.SetActive(false);
            equippedItem = null;
        }

        if (inventoryItems.Contains(item))
        {
            inventoryItems.Remove(item);
        }
    }

    private void EquipNextItem()
    {
        GameObject nextItem;


        int idx = inventoryItems.IndexOf(equippedItem);

        if (idx == inventoryItems.Count - 1)
        {
            nextItem = inventoryItems[0];
        } else
        {
            nextItem = inventoryItems[idx + 1];
        }

        if (equippedItem != null)
        {
            equippedItem.SetActive(false);
        }
        
        if (nextItem != null)
        {
            nextItem.SetActive(true);
        }

        equippedItem = nextItem;

        // TODO: slow player if they're holding the heavy stepping stone?
    }

    private void OnInventory(InputAction.CallbackContext context)
    {
        EquipNextItem();
    }

    public void UseItem(InventoryItem item)
    {
        switch (item)
        {
            case InventoryItem.FishFood:
                RemoveFromInventory(fishFood);
                break;

            case InventoryItem.SteppingStone:
                RemoveFromInventory(steppingStone);
                break;

            default:
                break;
        }
    }

    public bool IsEquipped(InventoryItem item)
    {
        switch (item)
        {
            case InventoryItem.FishFood:
                return equippedItem == fishFood;

            case InventoryItem.Rake:
                return equippedItem == rake;

            case InventoryItem.SteppingStone:
                return equippedItem == steppingStone;

            default:
                return false;
        }
    }

}

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

    public float timeout = 0.2f;
    private float _timeout;

    public enum InventoryItem
    {
        Rake,
        FishFood,
        SteppingStone
    }

    private void Awake()
    {
        inventoryItems = new List<GameObject>();
        inventoryItems.Add(null);
    }

    public void Add(InventoryItem item)
    {
        switch (item)
        {
                case InventoryItem.FishFood:
                inventoryItems.Add(fishFood);
                break;

            case InventoryItem.SteppingStone:
                inventoryItems.Add(steppingStone);
                break;

            case InventoryItem.Rake:
                inventoryItems.Add(rake);
                break;

            default:
                break;
        }
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

    private void Update()
    {
        if (inputManager.inventory && _timeout <= 0f)
        {
            EquipNextItem();
            _timeout = timeout;
            inputManager.inventory = false;
        } else
        {
            _timeout = Mathf.Clamp(_timeout - Time.deltaTime, -1f, timeout + 1f);
        }
    }

}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    public GameObject rake;
    public GameObject fishFood;
    public GameObject lighter;
    public GameObject steppingStone;

    public InputManager inputManager;
    private List<GameObject> inventoryItems;
    private GameObject equippedItem;

    private void Awake()
    {
        inventoryItems = new List<GameObject>();
        AddToInventory(null);
        AddToInventory(rake);
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

    private void removeFromInventory(GameObject item)
    {
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
    }

    private void OnInventory(InputAction.CallbackContext context)
    {
        EquipNextItem();
        Debug.Log("Q pressed!");
    }

}
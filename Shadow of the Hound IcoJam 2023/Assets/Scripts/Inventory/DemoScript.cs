using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public itemSO[] pickableItems;
    public void pickupItem(int id)
    {
        bool result = inventoryManager.addItem(pickableItems[id]);
        if (result)
        {
            Debug.Log("ITEM ADDED");
        }
        else
        {
            Debug.Log("ITEM NOT ADDED");
        }
    }
}

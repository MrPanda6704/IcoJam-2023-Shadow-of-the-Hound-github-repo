using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public int maxStack = 10;
    public GameObject inventoryItemPrefab;

    int selectedSlot = -1;

    private void Update()
    {
        if (Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int numberInput);
            if (isNumber && 0 < numberInput && numberInput < 8)
            {
                changeSelectSlot(numberInput - 1);
            }
        }
    }
    void changeSelectSlot(int newSlotID)
    {
        if (selectedSlot >=0)
        {
            inventorySlots[selectedSlot].deselect();
        }
        inventorySlots[newSlotID].select();
        selectedSlot = newSlotID;
    }
   public bool addItem(itemSO item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null && itemInSlot.item == item && itemInSlot.count < maxStack
                && itemInSlot.item.stackable)
            {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;
            }
        }

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                spawnNewItem(item, slot);
                return true;
            }
        }
        return false;

    }

    private void spawnNewItem(itemSO item, InventorySlot slot)
    {
        GameObject newItemGO = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGO.GetComponent<InventoryItem>();
        inventoryItem.intializeItem(item);
    }

    public itemSO GetSelectedItemSO()
    {
        InventorySlot slot = inventorySlots[selectedSlot];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if (itemInSlot != null)
        {
            return itemInSlot.item;
        }
        return null;
    }
}

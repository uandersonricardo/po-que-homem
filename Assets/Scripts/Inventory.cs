using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public static List<InventoryItem> items = new List<InventoryItem>();

    public static void AddItem(Item item)
    {
        items.Add(new InventoryItem(item, false));
        UIController.Instance.GetInventoryUI().UpdateItems();
    }

    public static void GiveItem(InventoryItem inventoryItem)
    {
        inventoryItem.isGiven = true;
        UIController.Instance.GetInventoryUI().UpdateItems();
    }

    public static InventoryItem GetItem(ItemType type)
    {
        return items.Find(inventoryItem => inventoryItem.type == type);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public static List<InventoryItem> items = new List<InventoryItem>();

    public static void AddItem(Item item)
    {
        items.Add(new InventoryItem(item, false));
    }

    public static void GiveItem(InventoryItem inventoryItem)
    {
        inventoryItem.isGiven = true;
    }

    public static InventoryItem GetItem(ItemType type)
    {
        return items.Find(inventoryItem => inventoryItem.item.type == type);
    }
}

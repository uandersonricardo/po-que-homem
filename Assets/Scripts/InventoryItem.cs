using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    public bool isGiven;
    public ItemType type;
    public Sprite sprite;
    public string itemName;
    public string description;

    public InventoryItem(Item item, bool isGiven = false)
    {
        this.type = item.type;
        this.sprite = item.sprite;
        this.itemName = item.itemName;
        this.description = item.description;
        this.isGiven = isGiven;
    }
}

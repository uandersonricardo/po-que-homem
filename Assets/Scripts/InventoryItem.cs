using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    public Item item;
    public bool isGiven;

    public InventoryItem(Item item, bool isGiven = false)
    {
        this.item = item;
        this.isGiven = isGiven;
    }
}

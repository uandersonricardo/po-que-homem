using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InventoryItemUI : MonoBehaviour
{
    private InventoryItem item;

    [SerializeField]
    private Image itemImage;

    [SerializeField]
    private GameObject border;

    private bool empty = true;

    public void Awake()
    {
        RemoveItem();
        Deselect();
    }

    public void Deselect()
    {
        border.SetActive(false);
    }

    public void Select()
    {
        border.SetActive(true);
    }

    public bool IsEmpty()
    {
        return empty;
    }

    public void SetItem(InventoryItem item)
    {
        this.itemImage.gameObject.SetActive(true);
        this.itemImage.sprite = item.sprite;
        this.item = item; 
        empty = false;
    }

    public InventoryItem GetItem()
    {
        return item;
    }

    public void RemoveItem()
    {
        this.itemImage.gameObject.SetActive(false);
        this.itemImage.sprite = null;
        this.item = null;
        empty = true;
    }
}

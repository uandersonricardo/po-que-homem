using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private InventoryItemUI[] inventoryItemsUI;
    [SerializeField] private InventoryDescriptionUI descriptionPanel;

    private int selectedItem = 0;
    private int inventorySize = 6;
    private int itemsPerRow = 2;

    public void UpdateItems()
    {
        List<InventoryItem> currentItems = Inventory.items.FindAll(item => !item.isGiven);

        for (int i = 0; i < inventorySize; i++)
        {
            if (currentItems.Count > i) {
                inventoryItemsUI[i].SetItem(Inventory.items[i]);
            } else {
                inventoryItemsUI[i].RemoveItem();
            }
        }
    }

    public void Show()
    {
        FindObjectOfType<PlayerInput>().enabled = false;
        SelectItem(0);
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        FindObjectOfType<PlayerInput>().enabled = true;
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            if (selectedItem % 2 == 0 && selectedItem + 1 < inventorySize)
            {
                SelectItem(selectedItem + 1);
            }
        }
        else if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            if (selectedItem % 2 == 1 && selectedItem > 0)
            {
                SelectItem(selectedItem - 1);
            }
        }
        else if (Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            if (selectedItem - itemsPerRow >= 0)
            {
                SelectItem(selectedItem - itemsPerRow);
            }
        }
        else if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            if (selectedItem + itemsPerRow < inventorySize)
            {
                SelectItem(selectedItem + itemsPerRow);
            }
        }
    }

    void SelectItem(int item, bool playSound = true)
    {
        if (item < 0 || item >= inventorySize) return;

        if (playSound)
        {
            SoundManager.Instance.PlaySound("Button");
        }

        if (!inventoryItemsUI[item].IsEmpty())
        {
            if (selectedItem >= 0 && selectedItem < inventorySize) inventoryItemsUI[selectedItem].Deselect();

            inventoryItemsUI[item].Select();
            selectedItem = item;
            descriptionPanel.UpdateDescription(inventoryItemsUI[item].GetItem());
        }
        else
        {
            if (selectedItem >= 0 && selectedItem < inventorySize)
            {
                if (inventoryItemsUI[selectedItem].IsEmpty()) inventoryItemsUI[selectedItem].Deselect();
                else return;
            }

            descriptionPanel.ResetDescription();
        }
    }
}

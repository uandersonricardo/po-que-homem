using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    List<InventoryItemUI> listOfUIItems = new List<InventoryItemUI>();

    [SerializeField]
    private InventoryItemUI itemPrefab;

    [SerializeField]
    private RectTransform contentPanel;

    [SerializeField]
    private InventoryDescriptionUI descriptionPanel;

    private int selectedItem = -1;
    private int inventorySize = 6;
    private int itemsPerRow = 3;

    public void InitializeInventoryUI()
    {
        // Cria os quadrados na UI
        for(int i = 0; i < inventorySize; i++)
        {
            InventoryItemUI uiItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(contentPanel);
            listOfUIItems.Add(uiItem);
        }

        UpdateItems();
    }

    public void UpdateItems()
    {
        // Remove todos os itens
        for (int i = 0; i < inventorySize; i++)
        {
            listOfUIItems[i].RemoveItem();
        }

        // Atribui itens aos quadrados
        int j = 0;
        for (int i = 0; i < Inventory.items.Count; i++)
        {
            if (!Inventory.items[i].isGiven) listOfUIItems[j++].SetItem(Inventory.items[i]);
        }
    }

    public void Show()
    {
        this.SelectItem(0);
        FindObjectOfType<PlayerInput>().enabled = false;
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
            if (selectedItem + 1 < inventorySize)
            {
                SelectItem(selectedItem + 1);
            }
        }
        else if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            if (selectedItem > 0)
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

        if (!listOfUIItems[item].IsEmpty())
        {
            if (selectedItem >= 0 && selectedItem < inventorySize) listOfUIItems[selectedItem].Deselect();
            listOfUIItems[item].Select();
            selectedItem = item;
            descriptionPanel.UpdateDescription(listOfUIItems[item].GetItem());
        }
        else
        {
            if (selectedItem >= 0 && selectedItem < inventorySize)
            {
                if (listOfUIItems[selectedItem].IsEmpty()) listOfUIItems[selectedItem].Deselect();
                else return;
            }
            
            descriptionPanel.ResetDescription();
        }
    }
}

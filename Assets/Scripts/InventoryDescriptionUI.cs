using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryDescriptionUI : MonoBehaviour
{
    public Image itemImage;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDescription;

    public void UpdateDescription(InventoryItem item)
    {
        itemImage.sprite = item.sprite;
        itemName.text = item.itemName;
        itemDescription.text = item.description;
    }

    public void ResetDescription()
    {
        itemImage.sprite = null;
        itemName.text = "";
        itemDescription.text = "";
    }
}

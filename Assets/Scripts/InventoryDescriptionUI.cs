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
        itemImage.gameObject.SetActive(true);
        itemImage.sprite = item.sprite;
        itemName.text = item.itemName;
        itemDescription.text = item.description;
    }

    public void ResetDescription()
    {
        itemImage.gameObject.SetActive(false);
        itemImage.sprite = null;
        itemName.text = "Inventário";
        itemDescription.text = "Nenhum item selecionado";
    }
}

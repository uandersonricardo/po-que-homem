using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryController : MonoBehaviour
{
    [SerializeField]
    private InventoryUI inventoryUI;

    void Start()
    {
        inventoryUI.InitializeInventoryUI();
    }

    void Update()
    {
        if (Keyboard.current.iKey.wasPressedThisFrame)
        {
            if (inventoryUI.isActiveAndEnabled == false)
            {
                inventoryUI.Show();
            }
            else
            {
                inventoryUI.Hide();
            }
        }
        else if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (inventoryUI.isActiveAndEnabled == true)
            {
                inventoryUI.Hide();
            }
        }
    }
}

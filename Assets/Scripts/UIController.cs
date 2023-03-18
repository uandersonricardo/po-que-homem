using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIController : MonoBehaviour
{
    private static UIController instance;
    public static UIController Instance => instance;

    private Flirt flirtUI;
    private Talk talkUI;
    private InventoryUI inventoryUI;
    private ConfirmLocation confirmLocationUI;

    private void Awake()
    {
        if (instance && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        confirmLocationUI = GetComponentInChildren<ConfirmLocation>(true);
        inventoryUI = GetComponentInChildren<InventoryUI>(true);
        flirtUI = GetComponentInChildren<Flirt>(true);
        talkUI = GetComponentInChildren<Talk>(true);

        inventoryUI.InitializeInventoryUI();
    }

    void Update()
    {
        // Apertou I => abre/fecha o inventário
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
    }

    public Flirt GetFlirtUI()
    {
        return flirtUI;
    }

    public Talk GetTalkUI()
    {
        return talkUI;
    }

    public InventoryUI GetInventoryUI()
    {
        return inventoryUI;
    }

    public ConfirmLocation GetConfirmLocationUI()
    {
        return confirmLocationUI;
    }
}

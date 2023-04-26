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
    private PauseMenu pauseMenuUI;
    private bool isShowing = false;

    private void Awake()
    {
        if (instance && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        confirmLocationUI = GetComponentInChildren<ConfirmLocation>(true);
        inventoryUI = GetComponentInChildren<InventoryUI>(true);
        flirtUI = GetComponentInChildren<Flirt>(true);
        talkUI = GetComponentInChildren<Talk>(true);
        pauseMenuUI = GetComponentInChildren<PauseMenu>(true);
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (inventoryUI.isActiveAndEnabled == false && Keyboard.current.iKey.wasPressedThisFrame)
        {
            inventoryUI.Show();
        }
        else if (inventoryUI.isActiveAndEnabled == true && (Keyboard.current.iKey.wasPressedThisFrame || Keyboard.current.escapeKey.wasPressedThisFrame))
        {
            inventoryUI.Hide();
        }
        else if (pauseMenuUI.isActiveAndEnabled == false && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            pauseMenuUI.Show();
        }
        else if (pauseMenuUI.isActiveAndEnabled == true && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            pauseMenuUI.Hide();
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

    public PauseMenu GetPauseMenuUI()
    {
        return pauseMenuUI;
    }

    public bool GetIsShowing()
    {
        return isShowing;
    }

    public void SetIsShowing(bool isShowing)
    {
        this.isShowing = isShowing;
    }
}

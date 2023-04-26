using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class Detect : MonoBehaviour
{
    private bool isClose;
    private CinemachineVirtualCamera mainCamera;
    private Man man;
    public GameObject ballon;
    public CinemachineVirtualCamera virtualCamera;
    public AudioSource playSource;
    public bool playIfGiven;

    // UI
    private Flirt flirtUI;
    private Talk talkUI;

    // Start is called before the first frame update
    void Start()
    {
        isClose = false;
        man = GetComponentInParent<Man>();
        mainCamera = GameObject.Find("Player Follow Camera").GetComponent<CinemachineVirtualCamera>();
        ballon.SetActive(false);

        flirtUI = UIController.Instance.GetFlirtUI();
        talkUI = UIController.Instance.GetTalkUI();

        InventoryItem inventoryItem = Inventory.GetItem(man.itemToGive);
        if (playIfGiven && playSource && inventoryItem != null && inventoryItem.isGiven) {
            playSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isClose && Keyboard.current.fKey.wasPressedThisFrame)
        {
            TalkTo();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && ContactList.GetContact(man.type) == null)
        {
            isClose = true;
            ballon.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isClose = false;
            ballon.SetActive(false);
        }
    }

    void TalkTo()
    {
        InventoryItem inventoryItem = Inventory.GetItem(man.itemToGive);

        if (inventoryItem == null || (man.type == "Maid" && ContactList.contacts.Count < 6 ))
        {
            talkUI.StartTalking(new List<string> { man.itemToGiveText }, man.type);
        }
        else if (!inventoryItem.isGiven)
        {
            if (!inventoryItem.isGiven) Inventory.GiveItem(inventoryItem);
            talkUI.StartTalking(new List<string> { man.thankText }, man.type);

            if (playSource) {
                playSource.Play();
            }
        }
        else
        {
            SetFlirtCamera();
            flirtUI.StartFlirting(man);
        }
    }

    public void SetFlirtCamera()
    {
        virtualCamera.gameObject.SetActive(true);
        mainCamera.gameObject.SetActive(false);
    }

    public void SetDefaultCamera()
    {
        virtualCamera.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);
    }
}

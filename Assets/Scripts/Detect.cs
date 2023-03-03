using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class Detect : MonoBehaviour
{
    private bool isClose;
    private CinemachineVirtualCamera vcam;
    private Transform defaultFollow;
    private Transform defaultLookAt;
    private Vector3 defaultOffset;
    private Man man;
    public GameObject heart;
    public Vector3 cameraOffset; 
    public Flirt flirtUi;
    public Talk talkUi;

    // Start is called before the first frame update
    void Start()
    {
        isClose = false;
        man = GetComponentInParent<Man>();
        vcam = FindObjectOfType<CinemachineVirtualCamera>();
        heart.SetActive(false);
        defaultFollow = vcam.Follow;
        defaultLookAt = vcam.LookAt;
        defaultOffset = vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset;
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
            heart.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isClose = false;
            heart.SetActive(false);
        }
    }

    void TalkTo()
    {
        InventoryItem inventoryItem = Inventory.GetItem(man.itemToGive);

        if (inventoryItem == null)
        {
            talkUi.StartTalking(new List<string> { man.itemToGiveText }, man.type);
        }
        else if (!inventoryItem.isGiven)
        {
            Inventory.GiveItem(inventoryItem);
            talkUi.StartTalking(new List<string> { man.thankText }, man.type);
        }
        else
        {
            SetFlirtCamera();
            flirtUi.StartFlirting(man);
        }
    }

    public void SetFlirtCamera()
    {
        vcam.Follow = transform;
        vcam.LookAt = transform;
        vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = cameraOffset;
    }

    public void SetDefaultCamera()
    {
        vcam.Follow = defaultFollow;
        vcam.LookAt = defaultLookAt;
        vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = defaultOffset;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CatchItem : MonoBehaviour
{
    private bool isClose;
    public GameObject balloon;

    // Start is called before the first frame update
    void Start()
    {
        if (Inventory.GetItem(GetComponentInChildren<Item>().type) != null)
        {
            Destroy(gameObject);
        }

        isClose = false;
        balloon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isClose && Keyboard.current.fKey.wasPressedThisFrame)
        {
            SoundManager.Instance.PlaySound("Pickup");
            Inventory.AddItem(GetComponentInChildren<Item>());
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isClose = true;
            balloon.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isClose = false;
            balloon.SetActive(false);
        }
    }
}

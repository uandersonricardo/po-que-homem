using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CatchItem : MonoBehaviour
{
    private bool isClose;
    private Animator playerAnimator;
    private PlayerInput playerInput;
    public GameObject balloon;

    // Start is called before the first frame update
    void Start()
    {
        if (Inventory.GetItem(GetComponentInChildren<Item>().type) != null)
        {
            Destroy(gameObject);
        }

        isClose = false;
        playerInput = FindObjectOfType<PlayerInput>();
        playerAnimator = FindObjectOfType<StarterAssets.ThirdPersonController>().GetComponent<Animator>();
        balloon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isClose && Keyboard.current.fKey.wasPressedThisFrame)
        {
            playerInput.enabled = false;
            playerAnimator.SetBool("Catch", true);
            StartCoroutine(Catch());
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

    IEnumerator Catch()
    {
        yield return new WaitForSeconds(1.2f);
        SoundManager.Instance.PlaySound("Pickup");
        Inventory.AddItem(GetComponentInChildren<Item>());
        playerAnimator.SetBool("Catch", false);
        gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
        balloon.SetActive(false);
        yield return new WaitForSeconds(5f);
        playerInput.enabled = true;
        Destroy(gameObject);
    }
}

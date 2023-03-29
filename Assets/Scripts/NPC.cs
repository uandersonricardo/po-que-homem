using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPC : MonoBehaviour
{
    private bool isClose;
    private Talk talkUI;

    public GameObject balloon;
    public string text;
    public string characterName;

    // Start is called before the first frame update
    void Start()
    {
        isClose = false;
        balloon.SetActive(false);
        talkUI = UIController.Instance.GetTalkUI();
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

    void TalkTo()
    {
        talkUI.StartTalking(new List<string> { text }, characterName);
    }
}

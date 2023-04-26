using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Talk : MonoBehaviour
{
    private int currentPhrase;
    private List<string> phrases;
    private string character;
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            NextPhrase();
        }
        else if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            ExitTalking();
        }
    }

    public void StartTalking(List<string> phraseList, string characterName, bool playSound = true)
    {
        if (UIController.Instance.GetIsShowing()) return;

        if (playSound) {
            SoundManager.Instance.PlaySound("Transition");
        }

        phrases = phraseList;
        character = characterName;
        SetPhrase(0);
        FindObjectOfType<PlayerInput>().enabled = false;
        gameObject.SetActive(true);
        UIController.Instance.SetIsShowing(true);
    }

    void SetPhrase(int phrase)
    {
        currentPhrase = phrase;
        panel.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = phrases[currentPhrase];
        panel.transform.Find("Person Frame").Find("Text").GetComponent<TextMeshProUGUI>().text = character;
    }

    void NextPhrase()
    {
        if (currentPhrase < phrases.Count - 1)
        {
            SetPhrase(currentPhrase + 1);
        }
        else
        {
            ExitTalking();
        }
    }

    void ExitTalking()
    {
        if (!UIController.Instance.GetIsShowing()) return;

        SoundManager.Instance.PlaySound("Transition");
        gameObject.SetActive(false);
        FindObjectOfType<PlayerInput>().enabled = true;
        FindObjectOfType<Detect>().SetDefaultCamera();
        UIController.Instance.SetIsShowing(false);
    }
}

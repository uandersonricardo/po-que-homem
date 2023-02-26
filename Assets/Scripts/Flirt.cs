using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class Flirt : MonoBehaviour
{
    private int currentDialogue;
    private int selectedButton;
    private Man selectedMan;
    public GameObject panel;
    public GameObject[] buttons;
    public Slider lovemeter;

    // Start is called before the first frame update
    void Start()
    {
        lovemeter.value = selectedMan.lovemeterParameters.startValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            if (selectedButton == 0 || selectedButton == 2)
            {
                SelectButton(selectedButton + 1);
            }
        }
        else if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            if (selectedButton == 1 || selectedButton == 3)
            {
                SelectButton(selectedButton - 1);
            }
        }
        else if (Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            if (selectedButton == 2 || selectedButton == 3)
            {
                SelectButton(selectedButton - 2);
            }
        }
        else if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            if (selectedButton == 0 || selectedButton == 1)
            {
                SelectButton(selectedButton + 2);
            }
        }
        else if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            ChooseOption(selectedButton);
        }
        else if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            SoundManager.Instance.PlaySound("Transition");
            gameObject.SetActive(false);
            FindObjectOfType<Detect>().SetDefaultCamera();
        }
    }

    public void StartFlirting(Man man)
    {
        SoundManager.Instance.PlaySound("Transition");
        selectedMan = man;
        SetDialogue(0);
        gameObject.SetActive(true);
    }

    void SelectButton(int button, bool playSound = true)
    {
        selectedButton = button;

        if (playSound) {
            SoundManager.Instance.PlaySound("Button");
        }

        for (int i = 0; i < buttons.Length; i++)
        {
            DisableButton(i);
        }

        EnableButton(button);
    }

    void DisableButton(int button)
    {
        buttons[button].GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.75f);
        buttons[button].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
        buttons[button].transform.Find("Selected").gameObject.SetActive(false);
    }

    void EnableButton(int button)
    {
        buttons[button].GetComponent<Image>().color = new Color(1f, 1f, 1f);
        buttons[button].GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
        buttons[button].transform.Find("Selected").gameObject.SetActive(true);
    }

    void SetDialogue(int dialogueIndex)
    {
        currentDialogue = dialogueIndex;
        Dialogue dialogue = selectedMan.dialogues[dialogueIndex];
        SelectButton(0, false);

        panel.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = dialogue.text;
        panel.transform.Find("Person Frame").Find("Text").GetComponent<TextMeshProUGUI>().text = selectedMan.type;

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].transform.Find("Text").GetComponent<TextMeshProUGUI>().text = dialogue.options[i].text;
        }
    }

    void ChooseOption(int option)
    {
        SoundManager.Instance.PlaySound("Select");
        Dialogue dialogue = selectedMan.dialogues[currentDialogue];
        lovemeter.transform.Find("Heart Frame").GetComponent<Animator>().Play("Scale Up");
        
        if (dialogue.options[option].correct)
        {
            lovemeter.value = Mathf.Clamp01(lovemeter.value + selectedMan.lovemeterParameters.hitValue);
        }
        else
        {
            lovemeter.value = Mathf.Clamp01(lovemeter.value - selectedMan.lovemeterParameters.missValue);
        }

        if (lovemeter.value >= 1)
        {
            // Win
        }
        else if (lovemeter.value <= 0 || currentDialogue >= selectedMan.dialogues.Count - 1)
        {
            // Lose
        }
        else
        {
            SetDialogue(currentDialogue + 1);
        }
    }

    void ScaleHeart()
    {
        lovemeter.transform.Find("Heart").localScale = new Vector3(1.1f, 1.1f, 1f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Flirt : MonoBehaviour
{
    private int selectedButton = 0;
    public GameObject[] buttons;
    public Slider lovemeter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            if (selectedButton == 0 || selectedButton == 2) {
                selectedButton++;
                SelectButton(selectedButton);
            }
        }
        else if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            if (selectedButton == 1 || selectedButton == 3)
            {
                selectedButton--;
                SelectButton(selectedButton);
            }
        }
        else if (Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            if (selectedButton == 2 || selectedButton == 3)
            {
                selectedButton -= 2;
                SelectButton(selectedButton);
            }
        }
        else if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            if (selectedButton == 0 || selectedButton == 1)
            {
                selectedButton += 2;
                SelectButton(selectedButton);
            }
        }
        else if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            lovemeter.value = 1f;
        }
        else if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            gameObject.SetActive(false);
            FindObjectOfType<Detect>().SetDefaultCamera();
        }
    }

    public void SelectButton(int button)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<RawImage>().color = new Color(1f, 1f, 1f, 0.5f);
        }

        buttons[selectedButton].GetComponent<RawImage>().color = Color.white;
    }
}

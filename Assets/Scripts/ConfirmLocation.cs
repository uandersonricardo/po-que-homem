using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class ConfirmLocation : MonoBehaviour
{
    private int selectedButton = 0;
    public GameObject[] buttons;
    public TextMeshProUGUI localText;
    private string local = "";
    private string sceneName = "";

    private Dictionary<string, string> sceneToString = new Dictionary<string, string>()
    {
        {"Classroom","Sala de Aula"},
        {"Gym", "Academia"},
        {"Player Apartment","Casa"},
        {"Bar", "Bar"},
        {"AnimeStore", "Lojinha Otaku"},
        {"Playground", "Praça" },
        {"Apartment", "Apartamento"}
    };

    public void SetScene(string scene)
    {
        local = sceneToString[scene];
        sceneName = scene;
        localText.text = local;
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            if (selectedButton == 0)
            {
                selectedButton++;
                SelectButton(selectedButton);
            }
        }
        else if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            if (selectedButton == 1)
            {
                selectedButton--;
                SelectButton(selectedButton);
            }
        }
        else if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            gameObject.SetActive(false);
            FindObjectOfType<EnterLocation>().SetDefaultCamera();
        }
        else if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            gameObject.SetActive(false);
            if (selectedButton == 0)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            }
            else
            {
                gameObject.SetActive(false);
                FindObjectOfType<EnterLocation>().SetDefaultCamera();
            }
        }
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
}

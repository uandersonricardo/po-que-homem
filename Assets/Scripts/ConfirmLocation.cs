using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ConfirmLocation : MonoBehaviour
{
    private int selectedButton = 0;
    public GameObject[] buttons;

    private string local = "";
    private string sceneName = "";

    private Dictionary<string, string> sceneToString = new Dictionary<string, string>()
    {
        {"Classroom","Sala de Aula"},
        {"Gym", "Academia"},
        {"Bedroom","Quarto"},
        {"Bar", "Bar"},
        {"AnimeStore", "Lojinha Geek"},
        {"Playground", "Praça" },
    };

    public void SetScene(string scene)
    {
        local = sceneToString[scene];
        sceneName = scene;
        gameObject.GetComponentInChildren<Text>().text = "Ir para " + local + "?";
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
            FindObjectOfType<EnterLocation>().SetDefaultCamera();
            if (selectedButton == 0)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            }
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

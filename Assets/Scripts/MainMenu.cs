using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    private int selectedButton;
    public GameObject[] buttons;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            if (selectedButton > 0)
            {
                SelectButton(selectedButton - 1);
            }
        }
        else if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            if (selectedButton < buttons.Length - 1)
            {
                SelectButton(selectedButton + 1);
            }
        }
        else if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            ChooseOption(selectedButton);
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

    void ChooseOption(int option)
    {
        SoundManager.Instance.PlaySound("Select");
        
        if (option == 0) {
            // Começa
            UnityEngine.SceneManagement.SceneManager.LoadScene("Backstory");
        } else if (option == 1) {
            // Controles
        } else if (option == 2) {
            // Sair
            Application.Quit();
        }
    }
}

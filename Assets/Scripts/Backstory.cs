using UnityEngine;
using UnityEngine.InputSystem;

public class Backstory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            SoundManager.Instance.PlaySound("Button");
            UnityEngine.SceneManagement.SceneManager.LoadScene("Playground");
        }
    }
}

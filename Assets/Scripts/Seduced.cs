using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Seduced : MonoBehaviour
{
    public RuntimeAnimatorController controller;
    public static GameObject character;
    public static string message;
    public static int previousScene;

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject instatiated = Instantiate(character, Vector3.zero, Quaternion.identity, transform);
        instatiated.transform.localPosition = Vector3.zero;
        instatiated.transform.rotation = Quaternion.Euler(0, 180, 0);
        instatiated.GetComponent<Animator>().runtimeAnimatorController = controller;
        FindObjectOfType<TextMeshProUGUI>().text = message;
        StartCoroutine(BackToPreviousScene());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator BackToPreviousScene()
    {
        yield return new WaitForSeconds(5);
        UIController.Instance.SetIsShowing(false);
        SceneManager.LoadScene(previousScene);
    }

    public static void Show(GameObject man, string type, int scene, Vector3 currentPosition)
    {
        if (UIController.Instance.GetIsShowing()) return;

        character = man;
        message = type + " conquistado!";
        previousScene = scene;
        SceneManager.LoadScene("Seduced");
        UIController.Instance.SetIsShowing(true);
    }
}

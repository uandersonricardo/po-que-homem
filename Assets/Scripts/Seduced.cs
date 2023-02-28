using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Seduced : MonoBehaviour
{
    private GameObject player;
    public RuntimeAnimatorController controller;
    public static GameObject character;
    public static string message;
    public static int previousScene;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.SetActive(false);
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
        player.SetActive(true);
        SceneManager.LoadScene(previousScene);
    }

    public static void Show(GameObject man, string type, int scene)
    {
        character = man;
        message = type + " conquistado!";
        previousScene = scene;
        SceneManager.LoadScene("Seduced");
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class Album : MonoBehaviour
{
    private bool isClose;
    private bool opened;
    private CinemachineVirtualCamera mainCamera;
    public GameObject ballon;
    public CinemachineVirtualCamera virtualCamera;
    public GameObject albumUi;

    // Start is called before the first frame update
    void Start()
    {
        isClose = false;
        mainCamera = GameObject.Find("Player Follow Camera").GetComponent<CinemachineVirtualCamera>();
        ballon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isClose)
        {
            if (Keyboard.current.fKey.wasPressedThisFrame && !opened)
            {
                OpenAlbum();
            }
            else if (Keyboard.current.escapeKey.wasPressedThisFrame && opened)
            {
                CloseAlbum();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isClose = true;
            ballon.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isClose = false;
            ballon.SetActive(false);
        }
    }

    void OpenAlbum()
    {
        if (UIController.Instance.GetIsShowing()) return;

        SoundManager.Instance.PlaySound("Transition");
        SetAlbumCamera();
        opened = true;
        FindObjectOfType<PlayerInput>().enabled = false;
        StartCoroutine(OpenAlbumCoroutine());
        UIController.Instance.SetIsShowing(true);
    }

    void CloseAlbum()
    {
        if (!UIController.Instance.GetIsShowing()) return;

        SoundManager.Instance.PlaySound("Transition");
        SetDefaultCamera();
        opened = false;
        FindObjectOfType<PlayerInput>().enabled = true;
        StartCoroutine(CloseAlbumCoroutine());
        UIController.Instance.SetIsShowing(false);
    }

    IEnumerator OpenAlbumCoroutine()
    {
        yield return new WaitForSeconds(1f);
        albumUi.SetActive(true);
    }

    IEnumerator CloseAlbumCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        albumUi.SetActive(false);
    }

    public void SetAlbumCamera()
    {
        virtualCamera.gameObject.SetActive(true);
        mainCamera.gameObject.SetActive(false);
    }

    public void SetDefaultCamera()
    {
        virtualCamera.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);
    }
}

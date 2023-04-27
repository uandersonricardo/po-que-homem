using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

// Similar ao Detect, por�m espec�fico para locais
public class EnterLocation : MonoBehaviour
{
    private bool isClose;
    private CinemachineVirtualCamera vcam;
    private Transform defaultFollow;
    private Transform defaultLookAt;
    private Vector3 defaultOffset;

    public Vector3 offset;
    public string sceneName;

    // UI
    private ConfirmLocation confirmLocation;

    // Start is called before the first frame update
    void Start()
    {
        confirmLocation = UIController.Instance.GetConfirmLocationUI();
        isClose = false;
        vcam = FindObjectOfType<CinemachineVirtualCamera>();
        defaultFollow = vcam.Follow;
        defaultLookAt = vcam.LookAt;
        defaultOffset = vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if (isClose && Keyboard.current.fKey.wasPressedThisFrame)
        {
            // Since we can only change to the secondary scenes from the Playground scene
            // if the sceneName is not Playground, this means the player is leaving the Playground scene
            if (sceneName != "Playground")
            {
                GameObject player = GameObject.FindWithTag("Player");
                SpawnPlayer.SetSpawnPlayground(player.transform.position);
                SpawnPlayer.SetOtherSpawn(Vector3.zero);
            }

            confirmLocation.gameObject.SetActive(true);
            confirmLocation.SetScene(sceneName);
            SetLocationCamera();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isClose = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isClose = false;
        }
    }

    public void SetLocationCamera()
    {
        FindObjectOfType<PlayerInput>().enabled = false;
        vcam.Follow = transform;
        vcam.LookAt = transform;
        vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = offset;
    }

    public void SetDefaultCamera()
    {
        FindObjectOfType<PlayerInput>().enabled = true;
        vcam.Follow = defaultFollow;
        vcam.LookAt = defaultLookAt;
        vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = defaultOffset;
    }
}

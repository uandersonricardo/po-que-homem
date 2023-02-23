using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class Detect : MonoBehaviour
{
    private bool isClose;
    private CinemachineVirtualCamera vcam;
    private Transform defaultFollow;
    private Transform defaultLookAt;
    private Vector3 defaultOffset;
    public GameObject heart;
    public GameObject ui;
    public Vector3 offset; 

    // Start is called before the first frame update
    void Start()
    {
        isClose = false;
        vcam = FindObjectOfType<CinemachineVirtualCamera>();
        heart.SetActive(false);
        defaultFollow = vcam.Follow;
        defaultLookAt = vcam.LookAt;
        defaultOffset = vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if (isClose && Keyboard.current.fKey.wasPressedThisFrame)
        {
            ui.SetActive(true);
            SetFlirtCamera();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isClose = true;
            heart.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isClose = false;
            heart.SetActive(false);
        }
    }

    public void SetFlirtCamera()
    {
        vcam.Follow = transform;
        vcam.LookAt = transform;
        vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = offset;
        FindObjectOfType<PlayerInput>().enabled = false;
    }

    public void SetDefaultCamera()
    {
        vcam.Follow = defaultFollow;
        vcam.LookAt = defaultLookAt;
        vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = defaultOffset;
        FindObjectOfType<PlayerInput>().enabled = true;
    }
}

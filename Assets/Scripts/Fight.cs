using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Fight : MonoBehaviour
{
    private bool lastLeft;
    private float lastTime;
    private float currentSpeed;
    public Animator animator;
    public Slider slider;
    public RawImage leftKey;
    public RawImage rightKey;

    // Start is called before the first frame update
    void Start()
    {
        lastLeft = false;
        lastTime = Time.time;
        currentSpeed = 1f;
        leftKey.rectTransform.localScale = new Vector3(1.25f, 1.25f, 1f);
        rightKey.rectTransform.localScale = new Vector3(1f, 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (lastLeft && Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            lastTime = Time.time;
            lastLeft = false;
            leftKey.rectTransform.localScale = new Vector3(1.25f, 1.25f, 1f);
            rightKey.rectTransform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (!lastLeft && Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            lastTime = Time.time;
            lastLeft = true;
            leftKey.rectTransform.localScale = new Vector3(1f, 1f, 1f);
            rightKey.rectTransform.localScale = new Vector3(1.25f, 1.25f, 1f);
        }

        float newSpeed = Mathf.Lerp(2f, 0.1f, (Time.time - lastTime));
        currentSpeed = Mathf.Lerp(currentSpeed, newSpeed, 0.01f);
        slider.value = currentSpeed / 2f;
        animator.speed = currentSpeed;
    }
}

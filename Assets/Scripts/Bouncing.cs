using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncing : MonoBehaviour
{
    public float speed = 1f;
    public float offset = 1f;
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(initialPosition.x, initialPosition.y + Mathf.Sin(Time.time * speed) * offset, initialPosition.z);
    }
}

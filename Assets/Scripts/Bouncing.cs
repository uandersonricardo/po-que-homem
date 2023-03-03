using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncing : MonoBehaviour
{
    public float speed = 1f;
    public float offset = 1f;
    public bool horizontal = false;
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = horizontal ? Vector3.right : Vector3.up;
        gameObject.transform.position = new Vector3(initialPosition.x, initialPosition.y, initialPosition.z) + direction * Mathf.Sin(Time.time * speed) * offset;
    }
}

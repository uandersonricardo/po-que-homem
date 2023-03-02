using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePlayer : MonoBehaviour
{
    private void Awake()
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.transform.position = gameObject.transform.position;
    }
}

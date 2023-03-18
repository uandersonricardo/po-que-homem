using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    private static Vector3 spawnPlayground = new Vector3(-14, 0, 55);
    private void Awake()
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.transform.position = spawnPlayground;
    }

    public static void SetSpawnPlayground(Vector3 position)
    {
        spawnPlayground = position;
    }
}

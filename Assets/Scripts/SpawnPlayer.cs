using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    private static Vector3 spawnPlayground = new Vector3(-14, 0, 55);
    private static Vector3 otherSpawn = Vector3.zero;
    private void Awake()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Playground") player.transform.position = spawnPlayground;
        else if (otherSpawn != Vector3.zero) player.transform.position = otherSpawn;
    }

    public static void SetSpawnPlayground(Vector3 position)
    {
        spawnPlayground = position;
    }

    public static void SetOtherSpawn(Vector3 position)
    {
        otherSpawn = position;
    }
}

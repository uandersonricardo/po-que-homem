using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LovemeterParameters
{
    [Range(0f, 1f)] public static float startValue = 0.25f;
    [Range(0f, 1f)] public static float missValue = 0.25f;
    [Range(0f, 1f)] public static float hitValue = 0.25f;
}

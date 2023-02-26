using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LovemeterParameters
{
    [Range(0f, 1f)] public float startValue = 0.5f;
    [Range(0f, 1f)] public float missValue = 0.25f;
    [Range(0f, 1f)] public float hitValue = 0.25f;
}

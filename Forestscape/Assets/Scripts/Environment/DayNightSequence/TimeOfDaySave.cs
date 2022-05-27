using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TimeOfDaySave")]
public class TimeOfDaySave : ScriptableObject
{
    [SerializeField] private float currentTimeOfDay;

    public float CurrentTimeOfDay => currentTimeOfDay;
}

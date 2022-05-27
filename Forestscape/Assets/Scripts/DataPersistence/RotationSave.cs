using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RotationSave")]
public class RotationSave : ScriptableObject
{
    [SerializeField] private Vector3[] rotation;

    public Vector3[] Rotation => rotation;
}

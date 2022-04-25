using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RotationSave")]
public class RotationSave : ScriptableObject
{
    [SerializeField] private Quaternion[] rotation;

    public Quaternion[] Rotation => rotation;
}

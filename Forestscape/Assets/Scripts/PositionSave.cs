using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PositionSave")]
public class PositionSave : ScriptableObject
{
    [SerializeField] private Vector3[] position ;

    public Vector3[] Position => position;
}

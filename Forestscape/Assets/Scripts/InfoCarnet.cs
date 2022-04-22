using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Data/Items")]
public class InfoCarnet : ScriptableObject
{
    public Sprite photo;
    public string descriptionText;
}

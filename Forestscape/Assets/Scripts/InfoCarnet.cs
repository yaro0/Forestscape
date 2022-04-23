using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
[CreateAssetMenu(fileName = "New Item", menuName = "Data/Items")]
public class InfoCarnet : ScriptableObject
=======
[CreateAssetMenu(fileName = "New Item", menuName = "Data/Items", order = 8)]
public class InfoCarnet : MonoBehaviour
>>>>>>> parent of 673fcb83 (make an asset for carnet)
{
    public Sprite photo;
    public string descriptionText;
}

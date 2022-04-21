using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PicturesObject")]
public class PicturesObject : ScriptableObject
{
    [SerializeField] private Sprite[] photos;
    
    public Sprite[] Photos => photos;
}

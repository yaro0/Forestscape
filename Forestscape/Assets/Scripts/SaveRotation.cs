using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ce code n'est pas nécessaire pour le moment, mais nous voulions l'utiliser si nous avions eu le temps de faire un sauvegarde du jeu.
public class SaveRotation : MonoBehaviour
{
    [SerializeField] private RotationSave rotation;
    [SerializeField] private int id;
    [SerializeField] GameObject player;
    private bool rotationSet = false;
    
    void Start()
    {
        
        if (rotation.Rotation[id] != null)
        {
            //prend la dernière rotation sauvegardé dans le scriptable object de rotation
            player.transform.eulerAngles = rotation.Rotation[id];
        }
    }

   
    void Update()
    {
        //si cela n'a pas été déja fait, prend la dernière rotation sauvegardé dans le scriptable object de rotation
        if (!rotationSet)
        {
            player.transform.eulerAngles = rotation.Rotation[id];
            rotationSet = true;
        }

        
        
       //sauve la nouvelle postion à chaque update() dans le scriptable object
        rotation.Rotation[id] = player.transform.eulerAngles;
    }

   
}

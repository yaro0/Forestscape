using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showInfo : MonoBehaviour
{
 
    [SerializeField] private PicturesObject picturesList;
    [SerializeField] int i;
    [SerializeField] GameObject info;
   
    void Update()
    {
        //si la photo a été prise alors montre l'info sur l'animal
        if(picturesList.Photos[i] != null){
            info.SetActive(true);
        }
    }
}

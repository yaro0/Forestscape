using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showInfo : MonoBehaviour
{
 
    [SerializeField] private PicturesObject picturesList;
    [SerializeField] int i;
    [SerializeField] GameObject info;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(picturesList.Photos[i] != null){
            info.SetActive(true);
        }
    }
}

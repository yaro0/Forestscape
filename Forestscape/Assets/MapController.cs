using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{

    [SerializeField]
    private GameObject map;
    private bool mapOpen = false;
   

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.M) && !mapOpen){
        map.active = true;
        mapOpen = true;
       } else if(Input.GetKeyDown(KeyCode.M) && mapOpen){
        map.active = false;
        mapOpen = false;
       }
    }
}

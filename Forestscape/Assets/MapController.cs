using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{

    [SerializeField]
    private GameObject map;
    private bool mapOpen = false;
    private Vector3 aPos;
   

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.M) && !mapOpen){
        map.active = true;
        mapOpen = true;
        
       } else if(Input.GetKeyDown(KeyCode.M) && mapOpen){
        //map.active = false;
        mapOpen = false;
       }

       if(mapOpen && map.GetComponent<RectTransform>().position.y < 520){
          aPos = map.GetComponent<RectTransform>().position;
          aPos.x = aPos.y = aPos.z = 0;
          aPos.y = 2000 * Time.deltaTime;
          map.GetComponent<RectTransform>().position += aPos;
       }

       if(!mapOpen && map.GetComponent<RectTransform>().position.y > -600){
          aPos = map.GetComponent<RectTransform>().position;
          aPos.x = aPos.y = aPos.z = 0;
          aPos.y = 2000 * Time.deltaTime;
          map.GetComponent<RectTransform>().position -= aPos;
       } else if(!mapOpen && map.GetComponent<RectTransform>().position.y < -600){
        map.active = false;
       }

    }
}

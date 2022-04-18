using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Worktable : MonoBehaviour
{

    private BoxCollider collider;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider>();
    }

    void OnTriggerStay(Collider collider) {  
       if(Input.GetKeyDown(KeyCode.E)){
           SceneManager.LoadScene (sceneName:"Workbench");
       }   
    }  
}

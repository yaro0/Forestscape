using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Worktable : MonoBehaviour
{

    public GameObject txtToDisplay;  
    private BoxCollider collider;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider>();
    }

    void OnTriggerStay(Collider collider) {  
       //txtToDisplay.GetComponent<Text>().text = "Appuyez 'E' pour interagir";
       if(Input.GetKeyDown(KeyCode.E)){
           SceneManager.LoadScene (sceneName:"Workbench");
       }   
    }  

    private void OnTriggerEnter(Collider collider)
    {
        txtToDisplay.SetActive(true);
    }

    private void OnTriggerExit(Collider collider)
    {
        txtToDisplay.SetActive(false);
    }


}

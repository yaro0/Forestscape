using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Worktable : MonoBehaviour
{

    public GameObject txtToDisplay;  
    private BoxCollider collider;
    
    void Start()
    {
        collider = GetComponent<BoxCollider>();
    }

    //quand on est devans la table on peut appuyer E pour ouvrir le worbench
    void OnTriggerStay(Collider collider) {  
       
       if(Input.GetKeyDown(KeyCode.E)){
           SceneManager.LoadScene (sceneName:"Workbench", LoadSceneMode.Additive);
       }   
    }  

    //texte apparait pour indiquer quoi appuyer au joueur
    private void OnTriggerEnter(Collider collider)
    {
        txtToDisplay.SetActive(true);
    }

    private void OnTriggerExit(Collider collider)
    {
        txtToDisplay.SetActive(false);
    }


}

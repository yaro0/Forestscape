using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneController : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject mountains;
    private int nbCurrentScenes;

    void Update()
    {
        //s'il y a plus que deux scenes, on désactive le joueur, le canvas et les montagnes 
        //(pour ne pas avoir de conflits avec les autre scenes, mais pour que le temps continu)
        nbCurrentScenes = SceneManager.sceneCount;
        if(nbCurrentScenes > 1){
            player.SetActive(false);
            canvas.SetActive(false);
            mountains.SetActive(false);
        } else {
            player.SetActive(true);
            canvas.SetActive(true);
            mountains.SetActive(true);
        }
        
    }
}

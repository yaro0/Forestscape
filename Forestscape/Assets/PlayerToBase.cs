using System.Collections.Generic;
using UnityEngine;


public class PlayerToBase : MonoBehaviour
{
    public GameObject player;
    public GameObject sceneManager;
    private LightingManager lightingManager;

    GameObject x;
    public Transform Target;

    private bool playerIsAtBase;
    
    void Start()
    {

        playerIsAtBase = false;

    }

    
    void Update()
    {
        returnPlayerToBase();
    }

    ///<summary>
    ///Retourne le joueur à sa position de départ dans la maison (déterminé par la variable Target) lors de la nuit
    ///</summary>
    private void returnPlayerToBase()
    {
        float time = sceneManager.GetComponent<LightingManager>().getTimeOfDay();

        if (time >= 2 && time <= 6 && !playerIsAtBase)
        {
            player.transform.position = Target.position;
            
        }
    }
}



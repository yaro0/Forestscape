using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SUPERCharacter;
using UnityEditor;

public class SavePosition : MonoBehaviour
{
    [SerializeField] private PositionSave position;
    [SerializeField] private int id;

    public GameObject player;
    public GameObject sceneManager;
    public GameObject x;
    private LightingManager lightingManager;

    
    public Transform Target;
    public PlayerToBase y;

    private bool playerIsAtBase;
    private bool setPosition = false;

    //ce code n'est pas nécessaire pour le moment, mais nous voulions l'utiliser si nous avions eu le temps de faire un sauvegarde du jeu.
    void Start()
    {
     
            GetComponent<SUPERCharacterAIO>().enabled = false;
            //prend la dernière position sauvegardé dans le scriptable object position
           player.transform.position = position.Position[id];
           
            StartCoroutine(wait(1));
            GetComponent<SUPERCharacterAIO>().enabled = true;
        
        
    }

    
    void Update()
    {
       
       //prend la dernière position suavegardé dans le scriptable object au premier load de la scene
        if(position.Position[id] != null && !setPosition)
        {
            player.transform.position = position.Position[id];
            setPosition = true;
            
        }

        //sauve la nouvelle position à chaque update() dans le scriptable object
        position.Position[id] = transform.position;
        

        returnPlayerToBase();
        
    }

    IEnumerator wait(int sec){
        yield return new WaitForSeconds(sec);
    }
    private void returnPlayerToBase()
    {
        float time = sceneManager.GetComponent<LightingManager>().getTimeOfDay();

        //après 23h le joueur retourne à la maison pour dormir
        if (time >= 23 &&  !playerIsAtBase)
        {
            player.transform.position = Target.position;
            
        }
    }
}

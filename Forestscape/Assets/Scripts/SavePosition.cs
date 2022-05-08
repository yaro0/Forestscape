using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SUPERCharacter;

public class SavePosition : MonoBehaviour
{
    [SerializeField] private PositionSave position;
    [SerializeField] private int id;

    public GameObject player;
    public GameObject sceneManager;
    public GameObject x;
    private LightingManager lightingManager;

    
    public Transform Target;
    public script y;

    private bool playerIsAtBase;
    private bool setPosition = false;
    
    // Start is called before the first frame update
    void Start()
    {
       // playerIsAtBase = false;

       

        //if(position.Position[id] != null )
        //{
            GetComponent<SUPERCharacterAIO>().enabled = false;
            player.transform.position = position.Position[id];
             StartCoroutine(wait(1));
            GetComponent<SUPERCharacterAIO>().enabled = true;
        //}
        
    }

    // Update is called once per frame
    void Update()
    {

        if(position.Position[id] != null && !setPosition)
        {
            player.transform.position = position.Position[id];
            setPosition = true;
            //GetComponent<SUPERCharacterAIO>().enabled = true;
        }
        
        position.Position[id] = transform.position;
        //GetComponent<SUPERCharacterAIO>().enabled = true;

        returnPlayerToBase();
        
    }

    IEnumerator wait(int sec){
        yield return new WaitForSeconds(sec);
    }
    private void returnPlayerToBase()
    {
        float time = sceneManager.GetComponent<LightingManager>().getTimeOfDay();

        if (time >= 23 &&  !playerIsAtBase)
        {
            player.transform.position = Target.position;
            
        }
    }
}

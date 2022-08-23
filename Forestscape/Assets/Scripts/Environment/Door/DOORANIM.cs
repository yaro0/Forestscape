using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine.UI;

public class DOORANIM : MonoBehaviour, IDataPersistence

{
//Base de code vient de l'Asset Store, du l'asset appelé "Apartment Door", il a ensuite été modifié pour être adapté à notre jeu
    public bool keyNeeded = false;              //Is key needed for the door
    public bool gotKey;                  //Has the player acquired key
    public GameObject keyGameObject;            //If player has Key,  assign it here
    public GameObject txtToDisplay;             //Display the information about how to close/open the door

    private bool playerInZone;                  //Check if the player is in the zone
    private bool doorOpened;                    //Check if door is currently opened or not

    private Animation doorAnim;
    private BoxCollider doorCollider;           //To enable the player to go through the door if door is opened else block him

    enum DoorState
    {
        Closed,
        Opened,
        Jammed
    }

    DoorState doorState = new DoorState();      //To check the current state of the door

    public void LoadData(GameData data)
    {
        this.doorOpened = data.doorOpened;
    }

    public void SaveData(ref GameData data)
    {
        data.doorOpened = this.doorOpened;
    }


    private void Start()
    {
        gotKey = false;
        //doorOpened = false;  //Is the door currently opened

        
        playerInZone = false;                   //Player not in zone
        //doorState = DoorState.Closed;           //Starting state is door closed

        txtToDisplay.SetActive(false);

        doorAnim = transform.parent.gameObject.GetComponent<Animation>();
        doorCollider = transform.parent.gameObject.GetComponent<BoxCollider>();

        //If Key is needed and the KeyGameObject is not assigned, stop playing and throw error
        if (keyNeeded && keyGameObject == null)
        {
            //UnityEditor.EditorApplication.isPlaying = false;
            Debug.LogError("Assign Key GameObject");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision happened");
        txtToDisplay.SetActive(true);
        playerInZone = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerInZone = false;
        txtToDisplay.SetActive(false);
    }

    private void Update()
    {
        //Debug.Log("Dorr exists");
        //To Check if the player is in the zone
        if (playerInZone)
        {
            Debug.Log("Dorr has been touched");
            if (doorState == DoorState.Opened)
            {
                txtToDisplay.GetComponent<Text>().text = "Appuyez 'E' pour interagir";
                //doorCollider.enabled = false;
            }
            else if (doorState == DoorState.Closed)//|| gotKey
            {
                txtToDisplay.GetComponent<Text>().text = "Appuyez 'E' pour interagir";
                doorCollider.enabled = true;
            }
            else if (doorState == DoorState.Jammed)
            {
                txtToDisplay.GetComponent<Text>().text = "Needs Key";
                doorCollider.enabled = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && playerInZone)
        {
            doorOpened = !doorOpened;           //The toggle function of door to open/close

            if (doorState == DoorState.Closed && !doorAnim.isPlaying)
            {
                if (!keyNeeded)
                {
                    doorAnim.Play("DoorOpen");
                    //UnityEngine.Animation:Play("DoorOpen");
                    doorState = DoorState.Opened;
                }
              
            }

            if (doorState == DoorState.Closed && gotKey && !doorAnim.isPlaying)
            {
                doorAnim.Play("DoorOpen");
                doorState = DoorState.Opened;
            }

            if (doorState == DoorState.Opened && !doorAnim.isPlaying)
            {
                doorAnim.Play("DoorClose");
                doorState = DoorState.Closed;
            }
            else if (doorState == DoorState.Jammed && gotKey && !doorAnim.isPlaying)
            {
                doorAnim.Play("DoorOpen");
                doorState = DoorState.Opened;
            }
        }
    }
}
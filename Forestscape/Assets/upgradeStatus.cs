using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeStatus : MonoBehaviour
{

    [SerializeField] private InventoryScript inventory;
    [SerializeField] private int id;
    [SerializeField] private GameObject goodBridge;
    [SerializeField] private GameObject brokenBridge;
    // Start is called before the first frame update
    void Start()
    {
        checkIfActive();
    }

    // Update is called once per frame
    void Update()
    {
        checkIfActive();
    }

    void checkIfActive(){
        Debug.Log(inventory.inventory[id]);
        if(inventory.inventory[id].Equals(true)){
            goodBridge.SetActive(true);
            brokenBridge.SetActive(false);
        } 
    }
}

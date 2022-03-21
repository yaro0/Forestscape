using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SUPERCharacter;

public class Lamp : MonoBehaviour, IInteractable
{
    public bool lampOpen = false;
    public bool Interact()
    {
        if (!lampOpen)
        {
            lampOpen = true;
            return true;
        }
        return false;
    }

    public void AddLight()
    {


    }
    
}

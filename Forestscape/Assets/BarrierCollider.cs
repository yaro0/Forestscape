using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierCollider : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit detected");
    }

}

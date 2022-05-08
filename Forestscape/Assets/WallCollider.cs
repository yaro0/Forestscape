using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollider : MonoBehaviour
{
    
    private void OnTriggerEnter(WallCollider other)
    {
        Debug.Log("hit detected");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursor : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}

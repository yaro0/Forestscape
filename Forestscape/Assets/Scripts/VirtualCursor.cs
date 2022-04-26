using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.EventSystems;

public class VirtualCursor : MonoBehaviour
{
    public Texture2D mouseCursor;
    Vector2 hotSpot = new Vector2(0, 0);
    CursorMode cursorMode = CursorMode.Auto;

    public void Start()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt) | Input.GetKeyDown(KeyCode.RightAlt))
        {
            Cursor.SetCursor(mouseCursor, hotSpot, cursorMode);
        }
        else
        {

        }
    }
}

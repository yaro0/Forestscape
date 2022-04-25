using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePosition : MonoBehaviour
{
    [SerializeField] private PositionSave position;
    [SerializeField] private int id;
    // Start is called before the first frame update
    void Start()
    {
        if(position.Position[id] != null)
        {
            transform.position = position.Position[id];
        }
    }

    // Update is called once per frame
    void Update()
    {
        position.Position[id] = transform.position;
    }
}

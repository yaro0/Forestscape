using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveRotation : MonoBehaviour
{
    [SerializeField] private RotationSave rotation;
    [SerializeField] private int id;
    // Start is called before the first frame update
    void Start()
    {
        if (rotation.Rotation[id] != null)
        {
            transform.rotation = rotation.Rotation[id];
        }
    }

    // Update is called once per frame
    void Update()
    {
        rotation.Rotation[id] = transform.rotation;
    }
}

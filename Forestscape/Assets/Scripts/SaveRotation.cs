using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveRotation : MonoBehaviour
{
    [SerializeField] private RotationSave rotation;
    [SerializeField] private int id;
    [SerializeField] GameObject player;
    private bool rotationSet = false;
    // Start is called before the first frame update
    void Start()
    {
        
        if (rotation.Rotation[id] != null)
        {
            Debug.Log("yes");
            player.transform.eulerAngles = rotation.Rotation[id];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!rotationSet)
        {
            player.transform.eulerAngles = rotation.Rotation[id];
            rotationSet = true;
        }
        

        StartCoroutine(wait());

        rotation.Rotation[id] = player.transform.eulerAngles;
    }

    IEnumerator wait(){

       yield return new WaitForSeconds(1); 
    }
}

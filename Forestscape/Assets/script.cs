using System.Collections.Generic;
using UnityEngine;


public class script : MonoBehaviour
{
    public GameObject player;
    public GameObject sceneManager;
    private LightingManager lightingManager;

    GameObject x;
    public Transform Target;

    private bool playerIsAtBase;
    // Start is called before the first frame update
    void Start()
    {

        playerIsAtBase = false;

    }

    // Update is called once per frame
    void Update()
    {
        returnPlayerToBase();
    }

    private void returnPlayerToBase()
    {
        float time = sceneManager.GetComponent<LightingManager>().getTimeOfDay();

        if (time >= 2 && time <= 6 && !playerIsAtBase)
        {
            player.transform.position = Target.position;
            //player.GetComponent<SUPERCharacterAIO>().enableMovementControl();
        }
    }
}



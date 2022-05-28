using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public float playerPositionx;

    public float playerPositiony;
    public float playerPositionz;


    //this constructor defines the default values, they're going to be used when theres no data to load
    public GameData()
    {
        this.playerPositionx = 425;
        this.playerPositiony = 66;
        this.playerPositionz = 608;
    }
}

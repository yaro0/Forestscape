using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    public static DataPersistenceManager instance { get; private set; }
    private GameData gameData;


    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Found more than one Data Persistence manager in the scene");
        }
        instance = this;

    }
    private void Start()
    {
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();

    }
    public void LoadGame()
    {
        //Load any saved data from a saved file using the data handler

        //if no data can be loaded, initialize to a new game
        if (this.gameData == null)
        {
            Debug.Log("No data was found. Initializing data to defaults.");
            NewGame();
        }

        //push the loaded data to all the other scripts of the game that need it

    }
    public void SaveGame()
    {
        //pass the data to other scripts so they can update it

        //save that data to a file using the data handler

    }
    private void OnApplicationQuit()
    {
        SaveGame();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class DataPersistenceManager : MonoBehaviour
{
    public static DataPersistenceManager instance { get; private set; }
    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;



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
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
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

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }

        Debug.Log("Loaded Door state" + gameData.doorOpened);

    }
    public void SaveGame()
    {
        //pass the data to other scripts so they can update it
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }
        //save that data to a file using the data handler
        Debug.Log("Saved Door state" + gameData.doorOpened);
    }
    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}

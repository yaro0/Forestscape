using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEditor;

public class SaveManager : MonoBehaviour
{
    public SaveData saveData;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //List<GameObject> gameObjectSaved = new List<GameObject>();
    
    public void Saving()
    {
        saveData.createList();
        //Scene sceneMain = SceneManager.GetSceneByName("MainScene");
        //sceneMain.GetRootGameObjects(gameObjectSaved);
    }
}

public class SaveData : MonoBehaviour
{
    //public GameObject prefabsAnimals;
    List<GameObject> animalsList = new List<GameObject>();

    public void createList()
    {
        //foreach (/*...*/)
        //{
            //animalsList.Add(go);
            //Debug.Log(go.name);
        //}
    }

}
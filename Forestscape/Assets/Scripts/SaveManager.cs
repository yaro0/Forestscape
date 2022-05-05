using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class SaveManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //List<GameObject> gameObjectSaved = new List<GameObject>();
    
    public void Saving()
    {

        //Scene sceneMain = SceneManager.GetSceneByName("MainScene");
        //sceneMain.GetRootGameObjects(gameObjectSaved);
    }
}

public class SaveData : MonoBehaviour
{
    //public GameObject prefabsAnimals;
    List<GameObject> animalsList = new List<GameObject>();

    private void createList()
    {
        
    }

}
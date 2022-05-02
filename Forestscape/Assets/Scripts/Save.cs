using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Save
{
    
    List<GameObject> gameObjectSaved = new List<GameObject>();
    
    public void Save()
    {
        Scene scene = SceneManager.GetSceneByName("MainScene");
        scene.GetRootGameObjects(gameObjectSaved);
    }
}

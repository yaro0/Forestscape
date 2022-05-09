using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
    Save save = new Save();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void newGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Exit()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }

    //public void
}

public class Save
{
    List<ScriptableObject> scripts = new List<ScriptableObject>();
    public void saving()
    {
        scripts.AddRange(Resources.FindObjectsOfTypeAll<ScriptableObject>());
        Debug.Log(scripts.ToString());
        //Scene scene = SceneManager.GetSceneByName("MainScene");
        //scene.GetRootGameObjects(gameObjectSaved);
    }
    
    //scriptableObject = Resources.Load<SomeScriptableObject>("AssetName");
}
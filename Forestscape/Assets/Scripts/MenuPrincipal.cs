using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEditor;

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
        SceneManager.LoadScene("VideoIntro");
    }

    public void Exit()
    {
        //Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }

    public void saving()
    {
        save.saving();
    }
}

public class Save
{
    List<ScriptableObject> scripts = new List<ScriptableObject>();
    public void saving()
    {
        foreach (ScriptableObject script in Resources.FindObjectsOfTypeAll<ScriptableObject>())
        {
            //if (AssetDatabase.AssetPathToGUID("Assets/Scripts") == script.) {

            //}
            
                //AssetDatabase.GetAssetPath(script) == "Assets/Scripts")
                //AssetDatabase.FindAssets
                //Contains(script))
                scripts.Add(script);
                Debug.Log(script.ToString());
            
            
            
            
        }
        //foreach (Resources.FindObjectsOfTypeAll<ScriptableObject>())
        //{
            //scripts.Add()
        //}
        //scripts.Add(Resources.FindObjectsOfTypeAll<ScriptableObject>());
        //Scene scene = SceneManager.GetSceneByName("MainScene");
        //scene.GetRootGameObjects(gameObjectSaved);
    }
    
    //scriptableObject = Resources.Load<SomeScriptableObject>("AssetName");
}
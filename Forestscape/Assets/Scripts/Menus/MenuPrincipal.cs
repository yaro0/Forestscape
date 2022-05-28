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
    //Save save = new Save();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Commence le jeu avec la vid�o d'intro
    /// </summary>
    public void newGame()
    {
        DataPersistenceManager.instance.NewGame();
        SceneManager.LoadScene("VideoIntro");
    }

    public void Exit()
    {
        //Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }

    /// <summary>
    /// Appel classe save code
    /// </summary>
    /*public void saving()
    {
        save.saving();
    }
    */
}

/// <summary>
/// Processus de save
/// </summary>
/*public class Save
{
    List<ScriptableObject> scripts = new List<ScriptableObject>();
    public void saving()
    {
        foreach (ScriptableObject script in Resources.FindObjectsOfTypeAll<ScriptableObject>())
        {
            scripts.Add(script);
            //Debug.Log(script.name.ToString());
        }
    }
}
*/

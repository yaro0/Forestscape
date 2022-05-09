using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
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
        UnityEditor.EditorApplication.isPlaying = false;
    }
}

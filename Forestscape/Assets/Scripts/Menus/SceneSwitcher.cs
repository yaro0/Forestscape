using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void LoadAdditiveScene(string name)
    {
        SceneManager.LoadScene(name,LoadSceneMode.Additive);
    }
    public void LoadScene(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void UnloadScene(string name)
    {
        SceneManager.UnloadScene(name);
    }

    
}

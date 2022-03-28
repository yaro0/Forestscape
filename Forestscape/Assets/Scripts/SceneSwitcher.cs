using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void GotoMenuScene()
    {
        SceneManager.LoadScene(0);
        //SceneManager.SetActiveScene(SceneManager.GetActiveScene());
    }

    public void GoToCraftingScene()
    {
        SceneManager.LoadScene(1);
        //SceneManager.SetActiveScene(SceneManager.GetActiveScene());
    }
}

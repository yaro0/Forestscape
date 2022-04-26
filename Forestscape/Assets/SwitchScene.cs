using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    [SerializeField] private KeyCode keycode;
    [SerializeField] private string sceneName;
    private void Update()
    {
        if (Input.GetKeyDown(keycode))
        {
            GetComponent<SceneSwitcher>().LoadScene(sceneName);
        }
    }

}

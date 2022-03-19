using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    //[Tooltip()]
    [SerializeField] private Text message;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void go()
    {
        Debug.Log("go======");

        message.text = "Message";
        SceneManager.LoadScene("");
    }
}

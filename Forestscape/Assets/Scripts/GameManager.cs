using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int sante;
    public static GameManager instance;
    // Start is called before the first frame update
    void Awake()

    {
        instance = this;
    }

    void Start()

    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoTransition : MonoBehaviour
{

    public VideoPlayer vid;
    public GameObject videoViewer;

    void Start()
    {
       
        vid.loopPointReached += CheckOver;
        videoViewer.SetActive(true);
        vid.enabled = true;
        vid.Play();
    }


    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        print("Video Is Over");
        videoViewer.SetActive(false);
        vid.enabled = false;

        SceneManager.LoadScene("MainScene");
    }

}


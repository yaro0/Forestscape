using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class SetTransparency : MonoBehaviour
{
     
    public float defaultTransparency = 1f;
    public float fadeDuration = 3f;
    private float timeOfDay;

    public float fadeInTime;
    public float fadeOutTime;
    public GameObject sceneManager;

    public bool isClouds;
     
    float currentTransparency;  
    float toFadeTo;
    float tempDist;
    bool isFadingUp;
    bool isFadingDown;
     
     
     
    void Start()
    {
        currentTransparency = defaultTransparency;
        ApplyTransparency();
    }
     
    void FixedUpdate(){

        timeOfDay = sceneManager.GetComponent<LightingManager>().getTimeOfDay();
        if(timeOfDay > fadeInTime){
            FadeT(1);
        } else if(timeOfDay > fadeOutTime){
            currentTransparency = 0;
            ApplyTransparency();
        }

/*
        if(isClouds && timeOfDay > fadeInTime && timeOfDay < fadeOutTime){
            GetComponent<MeshRenderer>().enabled = true;
        } else if(isClouds && timeOfDay > fadeInTime) {
            GetComponent<MeshRenderer>().enabled = false;
        }
        */
        
           
        if(isFadingUp){
            if(currentTransparency < toFadeTo){
                currentTransparency += (tempDist/fadeDuration) * Time.deltaTime;
                ApplyTransparency();
            }else{
                isFadingUp = false;
            }
        }
        else if(isFadingDown){
            if(currentTransparency > toFadeTo){
                currentTransparency -= (tempDist/fadeDuration) * Time.deltaTime;
                ApplyTransparency();
            }else{
                isFadingDown = false;
            }
        }
    }
     
    void ApplyTransparency(){
        GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, currentTransparency);
    }
 
 
 
    public void SetT(float newT){
        currentTransparency = newT;
        ApplyTransparency();
    }
     
    public void FadeT(float newT){
        toFadeTo = newT;
        if(currentTransparency < toFadeTo){
            tempDist = toFadeTo - currentTransparency;
            isFadingUp = true;
        }else{
            tempDist = currentTransparency - toFadeTo;
            isFadingDown = true;
        }
    }
     
     
}

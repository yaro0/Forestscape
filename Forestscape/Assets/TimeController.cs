using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

//https://youtu.be/L4t2c1_Szdk

public class TimeController : MonoBehaviour
{

[SerializeField]
    private float timeMultiplier;

[SerializeField]
    private float startHour;

    [SerializeField]
    private TextMeshProUGUI timeText;

    [SerializeField]
    private Light sunLight;

    [SerializeField]
    private float sunriseHour;
    [SerializeField]
    private float sunsetHour;

    [SerializeField]
    private Color dayAmbientLight;
    [SerializeField]
    private Color nightAmbientLight;

    [SerializeField]
    private AnimationCurve lightChangeCurve;
    [SerializeField]
    private float maxSunLightIntesity;

    [SerializeField]
    private Light moonLight;
    [SerializeField]
    private float maxMoonLightIntesity;

    private TimeSpan sunriseTime;
    private TimeSpan sunsetTime;

    private DateTime currentTime;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = DateTime.Now.Date + TimeSpan.FromHours(startHour);

        sunriseTime = TimeSpan.FromHours(sunriseHour);
        sunriseTime = TimeSpan.FromHours(sunsetHour);
    }

    // Update is called once per frame
    void Update()
    {
        updateTimeOfDay();
        rotateSun();
        UpdateLightSettings();
    }

    private void updateTimeOfDay(){
        currentTime = currentTime.AddSeconds(Time.deltaTime*timeMultiplier);
        if(timeText != null){
            timeText.text = currentTime.ToString("HH:mm");//Hour, minutes
        }
    }

    private TimeSpan CalculateTimeDifference(TimeSpan fromTime, TimeSpan toTime){
        TimeSpan difference = toTime - fromTime;

        if(difference.TotalSeconds <0){
            difference += TimeSpan.FromHours(24);
        }

        return difference;
    }

    private void rotateSun(){
        float sunLightRotation;

        if(currentTime.TimeOfDay > sunriseTime && currentTime.TimeOfDay < sunsetTime){
            TimeSpan sunriseToSunsetDuration = CalculateTimeDifference(sunriseTime,sunsetTime);
            TimeSpan timeSinceSunrise = CalculateTimeDifference(sunriseTime,currentTime.TimeOfDay);

            double percentage = timeSinceSunrise.TotalMinutes / sunriseToSunsetDuration.TotalMinutes;
            sunLightRotation = Mathf.Lerp(0,180, (float)percentage);// lerp
        } else {
            TimeSpan sunsetToSunriseDuration = CalculateTimeDifference(sunsetTime,sunriseTime);
            TimeSpan timeSinceSunset = CalculateTimeDifference(sunsetTime,currentTime.TimeOfDay);

            double percentage = timeSinceSunset.TotalMinutes / sunsetToSunriseDuration.TotalMinutes;
            sunLightRotation = Mathf.Lerp(180,360, (float)percentage);// lerp
        }

        sunLight.transform.rotation = Quaternion.AngleAxis(sunLightRotation,Vector3.right);
    }

    private void UpdateLightSettings(){
        float dotProduct = Vector3.Dot(sunLight.transform.forward, Vector3.down);
        sunLight.intensity = Mathf.Lerp(0, maxSunLightIntesity, lightChangeCurve.Evaluate(dotProduct));
        moonLight.intensity = Mathf.Lerp(maxMoonLightIntesity, 0, lightChangeCurve.Evaluate(dotProduct));
        RenderSettings.ambientLight = Color.Lerp(nightAmbientLight, dayAmbientLight, lightChangeCurve.Evaluate(dotProduct));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//inspiré de https://youtu.be/m9hj9PdO328
[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    //References
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPresets Preset;
    //Variables
    [SerializeField, Range(0,24)] private float TimeOfDay;

    [SerializeField]
    private TextMeshProUGUI timeText;
    public Image img;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        skipNight();
        updateTimeOfDayText();

        if(Preset == null)
        {
            return;
        }

        if (Application.isPlaying)
        {
            TimeOfDay += Time.deltaTime/50;
            TimeOfDay %= 24; //Clamp between 0-24
            UpdateLighting(TimeOfDay / 24f);
        }
        else
        {
            UpdateLighting(TimeOfDay / 24f);
        }

    }

    //saute la nuit en faisant un fade in et out
    private void skipNight(){
        if(TimeOfDay >= 22.99 ){
            

        StartCoroutine(FadeImage());
        }

        if(TimeOfDay >= 23.01 ){
            TimeOfDay = 6;
        }
        
    }

    // source: https://forum.unity.com/threads/simple-ui-animation-fade-in-fade-out-c.439825/
     IEnumerator FadeImage()
    {
        // fade from transparent to opaque
        // loop over 1 second
            for (float i = 0; i <= 2; i += Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(0, 0, 0, i);

                yield return null;
            }
            
            // fade from opaque to transparent
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(0, 0, 0, i);

                yield return null;
            }
           
        
    }
    


    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);

        if (DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }

    }

    private void OnValidate()
    {
        if (DirectionalLight != null)
            return;

        if(RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach(Light light in lights)
            {
                if(light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }
        }
    }

    private void updateTimeOfDayText()
    {
        if (timeText != null)
        {
            System.TimeSpan time = System.TimeSpan.FromHours(TimeOfDay);
            timeText.text = time.ToString("hh':'mm");//Hour, minutes
        }
    }

[SerializeField]
    public float getTimeOfDay()
    {
        return TimeOfDay;
    }
    
}

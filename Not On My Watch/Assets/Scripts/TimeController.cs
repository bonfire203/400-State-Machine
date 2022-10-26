using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class TimeController : MonoBehaviour
{
    [SerializeField]
    private float timeMultiplier; // controls how fast time passes 

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
    private AnimationCurve lightChangeCurve; // Transition between dayambient and night ambient smoothly 
    
    [SerializeField]
    private float maxSunLightIntensity;

    [SerializeField]
    private Light moonLight;
    
    [SerializeField]
    private float maxMoonLightIntensity;

    private DateTime currentTime; // keep track of time 
    
    private TimeSpan sunriseTime;

    private TimeSpan sunsetTime;

    private bool isDayTime;

    private int counter = 0;


    void Start()
    {
        currentTime = DateTime.Now + TimeSpan.FromHours(startHour); // 
        sunriseTime = TimeSpan.FromHours(sunriseHour);
        sunsetTime = TimeSpan.FromHours(sunsetHour);
        isDayTime = currentTime.TimeOfDay > sunriseTime && currentTime.TimeOfDay < sunsetTime;
        if (!isDayTime)
        {
            doNightTimeStuff();
        }
        else
        {
            doDayTimeStuff();
        }
    }

    
    void Update()
    {
        UpdateTimeofDay();
        RotateSun();
        UpdateLightSettings();
        detectDayNightChange();
    }

    private void UpdateTimeofDay()
    {
        currentTime = currentTime.AddSeconds(Time.deltaTime * timeMultiplier); // Time.delta time will gives the amount of actual seconds that have passed 
        if (timeText != null)
        {
            timeText.text = currentTime.ToString("HH:mm"); // display the time in 24 hour format
        }
    }

    private void doDayTimeStuff()
    {
        Debug.Log("day time");
        counter += 1;
       // if(counter == 3) nDay();
    }

    private void doNightTimeStuff()
    {
        Debug.Log("night time");
        counter += 1;
    }

    private void nDay()
    {
        SceneManager.LoadScene("Score");
    }

    private void detectDayNightChange()
    {
        bool newlyCalculatedIsDay = currentTime.TimeOfDay > sunriseTime && currentTime.TimeOfDay < sunsetTime;
        if (newlyCalculatedIsDay != isDayTime)
        {
            isDayTime = newlyCalculatedIsDay;
            if (!isDayTime)
            {
                doNightTimeStuff();
            }
            else
            {
                doDayTimeStuff();
            }
        }
    }
    
    private void RotateSun()
    {
        float sunLightRotation;
        
        
        if(currentTime.TimeOfDay > sunriseTime && currentTime.TimeOfDay < sunsetTime) // Daytime 
        {
            // if (!isDayTime)
            // {
            //     isDayTime = true;
            // }
            TimeSpan sunriseToSunsetDuration = CalculateTimeDifference(sunriseTime, sunsetTime); // Calculating the total time between sunrise and sunset
            TimeSpan timeSinceSunrise = CalculateTimeDifference(sunriseTime, currentTime.TimeOfDay); // How much time has passed since sunrise

            double percentage = timeSinceSunrise.TotalMinutes / sunriseToSunsetDuration.TotalMinutes; // Calculating the percentage of the day time that has passed 

            sunLightRotation = Mathf.Lerp(0, 180, (float)percentage); // set the rotation value to zero at sunrise  
            
            // Lerp linearly interpolates between two points 
        }
        else // Nighttime 
        {
            // if (isDayTime)
            // {
            //     isDayTime = false;
            // }
            TimeSpan sunsetToSunriseDuration = CalculateTimeDifference(sunsetTime, sunriseTime); // suntset -> sunrise
            TimeSpan timeSinceSunset = CalculateTimeDifference(sunsetTime, currentTime.TimeOfDay); // Time since sunset 

            double percentage = timeSinceSunset.TotalMinutes / sunsetToSunriseDuration.TotalMinutes;

            sunLightRotation = Mathf.Lerp(180, 360, (float)percentage);
            
        }

        sunLight.transform.rotation = Quaternion.AngleAxis(sunLightRotation, Vector3.right); // rotate around x axis. Alter sun light according to rotation 

    }

    private TimeSpan CalculateTimeDifference(TimeSpan fromTime, TimeSpan toTime)
    {
        TimeSpan difference = toTime - fromTime;

        if(difference.TotalSeconds < 0) // If the difference is negative day has passed 
        {
            difference += TimeSpan.FromHours(24);
        }

        return difference;
    }
   

    private void UpdateLightSettings()
    {
        float dotProduct = Vector3.Dot(sunLight.transform.forward, Vector3.down); // Midday the suyn is most intense. Sun points directly down 1 horizontally 0 pointing up - 1 
        sunLight.intensity = Mathf.Lerp(0, maxSunLightIntensity, lightChangeCurve.Evaluate(dotProduct)); // create non linear transition
        moonLight.intensity = Mathf.Lerp(maxMoonLightIntensity, 0, lightChangeCurve.Evaluate(dotProduct)); 
        RenderSettings.ambientLight = Color.Lerp(nightAmbientLight, dayAmbientLight, lightChangeCurve.Evaluate(dotProduct));
    }
}   


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Experimental.Rendering.Universal;

public class DayNightController : MonoBehaviour
{
    const float secondsInDay = 86400;
    [SerializeField]
    AnimationCurve nightTimeCurve;
    [SerializeField]
    Color nightLightColour;
    [SerializeField]
    Color dayLightColour = Color.white;
    float time;
    [SerializeField]
    Light2D globalLight;
    [SerializeField]
    TMP_Text text;
    [SerializeField]
    float timeScale = 600f;
    private float days;

    private float Hours 
    {
        get {return time / 3600f; }
    }
    private float Minutes 
    {
        get 
        { return time % 3600f / 60f; }
    }
    private void Update() {
        time += Time.deltaTime * timeScale; 
        text.text = ((int)Hours).ToString("00") + ":" + ((int)Minutes).ToString("00");
        float timeOnCurve = nightTimeCurve.Evaluate(Hours);
        Color transitionColour = Color.Lerp(dayLightColour, nightLightColour, timeOnCurve);
        globalLight.color = transitionColour;
        if (time > secondsInDay)
        {
            NextDay();
        }
    }
    void NextDay()
    {
        //Reset time and increment day
        time = 0;
        days++;
    }
}

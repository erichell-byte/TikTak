using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public Transform hoursTransform, minutesTransform, secondsTransform;
    float degreesPerHour = 30f;
    float degreesPerMinute = 6f;
    float degreesPerSecond = 6f;
    float secondsNew = 60f, minutesNew = 60f, hoursNew = 12f;
    public Text second;
    public Text minutes;
    public Text hours;
    public float param;
    static float second1;
    static float minuta1;
    static float hours1;
    static DateTime timeSpan;


    private void Awake()
    {
        TimerUpdate();
    }

    void TimerUpdate()
    {
        DateTime time = CheckGlobalTime();
        hoursTransform.localRotation = Quaternion.Euler(0f, time.Hour * degreesPerHour, 0f);
        minutesTransform.localRotation = Quaternion.Euler(0f, time.Minute * degreesPerMinute, 0f);
        secondsTransform.localRotation = Quaternion.Euler(0f, time.Second * degreesPerSecond, 0f);
        second.text = "" + (time.Second * (60f / secondsNew));
        minutes.text = "" + (time.Minute * (60f / minutesNew)) + "  :";
        hours.text = "" + (time.Hour * (12f / hoursNew)) + "  :";
        second1 = time.Second;
        minuta1 = time.Minute;
        hours1 = time.Hour + 3;

    }
    private void Update()
    {
        //hoursTransform.localRotation = Quaternion.Euler(0f, timeSpan.Hour * degreesPerHour, 0f);
        // minutesTransform.localRotation = Quaternion.Euler(0f, timeSpan.Minute * degreesPerMinute, 0f);
        // secondsTransform.localRotation = Quaternion.Euler(0f, timeSpan.Second * degreesPerSecond, 0f);
        // second.text = "" + (timeSpan.Second * (60f / secondsNew));
        //  minutes.text = "" + (timeSpan.Minute * (60f / minutesNew)) + "  :";
        // hours.text = "" + (timeSpan.Hour * (12f / hoursNew)) + "  :";
        //Debug.Log(timeSpan.Second);
        //Debug.Log(timeSpan.Minute);
        //Debug.Log(timeSpan.Hour);
        TimeCalc();

    }
    
    void TimeCalc()
    {
        param -= Time.deltaTime;
        if (param <= 0)
        {
            param = 1;
            second1 = second1 + 1;
        }

        if (second1 + timeSpan.Second >= 60)
        {
            minuta1 = minuta1 + 1;
            second1 = 0;
        }

        if (minuta1 + timeSpan.Minute >= 60)
        {
            hours1 = hours1 + 1;
            TimerUpdate();
            minuta1 = 0;
        }

        if (hours1 + timeSpan.Hour > 23)
        {
            hours1 = 0;
        }

        second.text = "" + second1;
        minutes.text = "" + minuta1 + "  :";
        hours.text = "" + hours1 + "  :";
        hoursTransform.localRotation = Quaternion.Euler(0f, hours1 * degreesPerHour, 0f);
        minutesTransform.localRotation = Quaternion.Euler(0f, minuta1 * degreesPerMinute, 0f);
        secondsTransform.localRotation = Quaternion.Euler(0f, second1 * degreesPerSecond, 0f);
    }

    DateTime CheckGlobalTime()
    {
        var site1 = new WWW("https://google.com");
        while (!site1.isDone && site1.error == null)
            Thread.Sleep(1);

        var str = site1.responseHeaders["Date"];
        DateTime dateTime;

        if (!DateTime.TryParse(str, out dateTime))
            return DateTime.MinValue;

        return dateTime.ToUniversalTime();
    }
}

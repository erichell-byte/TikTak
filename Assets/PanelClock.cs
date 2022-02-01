using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class PanelClock : MonoBehaviour
{
    float secondsNew = 60f, minutesNew = 60f, hoursNew = 12f;
    public Text second;
    public Text minutes;
    public Text hours;

    void Update()
    {

        DateTime time = DateTime.Now;
        second.text = "" + (time.Second * (60f / secondsNew));
        minutes.text = "" + (time.Minute * (60f / minutesNew)) + "  :";
        hours.text = "" + (time.Hour * (12f / hoursNew)) + "  :";
    }

}

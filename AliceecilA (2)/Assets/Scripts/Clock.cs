using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public Transform secondH;
    public Transform minuteH;
    public Transform hourH;

    // Update is called once per frame
    void Update()
    {
        DateTime current = DateTime.Now;
        float seconds = (float)current.Second;
        float minutes = (float)current.Minute;
        float hours = (float)current.Hour;

        float secondAngle = -360 * (seconds / 60);
        float minuteAngle = -360 * (minutes / 60);
        float hourAngle = -360 * (hours / 12);

        secondH.localRotation = Quaternion.Euler(0, 0, secondAngle);
        minuteH.localRotation = Quaternion.Euler(0, 0, minuteAngle);
        hourH.localRotation = Quaternion.Euler(0, 0, hourAngle);
    }
}

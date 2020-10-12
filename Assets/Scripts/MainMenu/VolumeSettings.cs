using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSettings : MonoBehaviour
{
    public Transform knob;
    public Transform start;
    public Transform end;
    public float volume;

    private Vector3 lastPos;
    private float abstand;
    private float einProzent;

    private void Start()
    {
        lastPos = knob.position;
        abstand = distance(end.position, start.position);
        einProzent = abstand / 100;
    }

    void FixedUpdate()
    {
        if (knob.position != lastPos)
        {
            lastPos = knob.position;
            float distanceToStart = distance(knob.position, start.position);
            volume = distanceToStart / einProzent;
            Debug.Log(volume);
        }
    }

    float distance(Vector3 a, Vector3 b)
    {
        Vector3 VerbindungsVector = b - a;
        double x = Math.Pow(VerbindungsVector.x, 2);
        double y = Math.Pow(VerbindungsVector.y, 2);
        double z = Math.Pow(VerbindungsVector.z, 2);
        float distance = (float)Math.Sqrt(x + y + z);
        return distance;
    }
}

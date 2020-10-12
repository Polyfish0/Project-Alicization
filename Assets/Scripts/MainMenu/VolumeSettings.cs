using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    public Transform knob;
    public Transform start;
    public Transform end;
    public AudioMixer audioMixer;
    public float volume;

    private Vector3 lastPos;
    private float abstand;
    private float einProzent;

    private void Start()
    {
        abstand = end.position.x - start.position.x;
        einProzent = abstand / 100;

        float currentVolume;
        audioMixer.GetFloat("MasterVolume", out currentVolume);
        float distanceToStart = (currentVolume + 80) * einProzent;
        knob.position = new Vector3(start.position.x + distanceToStart, start.position.y, start.position.z);

        lastPos = new Vector3((int)knob.position.x, (int)knob.position.y, (int)knob.position.z);
    }

    void FixedUpdate()
    {
        if (new Vector3((int)knob.position.x, (int)knob.position.y, (int)knob.position.z) != lastPos)
        {
            lastPos = new Vector3((int)knob.position.x, (int)knob.position.y, (int)knob.position.z);
            float distanceToStart = knob.position.x - start.position.x;
            volume = distanceToStart / einProzent;
            Debug.Log(volume);
            float decibel = volume - 80;
            SetVolume(decibel);
        }
    }

    void SetVolume(float decibel)
    {
        audioMixer.SetFloat("MasterVolume", decibel);
    }
}

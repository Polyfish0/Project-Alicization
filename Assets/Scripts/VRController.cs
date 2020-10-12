using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Valve.VR;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;
using Vector2 = UnityEngine.Vector2;

public class VRController : MonoBehaviour
{
    public float m_Speed = 1.0f;
    public Transform m_Camera;
    public Vector3 m_NewLocation = Vector3.zero;
    private SteamVR_Action_Vector2 m_LeftThumbstick;

    // Start is called before the first frame update
    void Start()
    {
        m_LeftThumbstick = SteamVR_Input.GetVector2Action("thumbstickleftmove");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 m_ThumbstickVector = m_LeftThumbstick.GetAxis(SteamVR_Input_Sources.LeftHand);
        float m_RealSpeed = m_Speed * Time.deltaTime;
        //Debug.Log("x: " + m_ThumbstickVector.x + ", y: " + m_ThumbstickVector.y);
        m_NewLocation = m_Camera.TransformDirection(new Vector3(m_ThumbstickVector.x, 0, m_ThumbstickVector.y)) * m_RealSpeed;
        Debug.Log("x: " + m_NewLocation.x + ", z: " + m_NewLocation.z);
        transform.Translate(m_NewLocation);
    }
}
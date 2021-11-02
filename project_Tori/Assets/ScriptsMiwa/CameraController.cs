using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    CinemachineFreeLook freeLook;

    void Start()
    {
        freeLook = GetComponent<CinemachineFreeLook>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            freeLook.m_XAxis.m_MaxSpeed = 200;
            freeLook.m_YAxis.m_MaxSpeed = 2;
        }

        if(Input.GetMouseButtonUp(0))
        {
            freeLook.m_XAxis.m_MaxSpeed = 0;
            freeLook.m_YAxis.m_MaxSpeed = 0;
        }

        if(Input.GetMouseButtonDown(1))
        {
            freeLook.m_XAxis.Value = 0;
            freeLook.m_YAxis.Value = 0.5f;
        }

    }
}

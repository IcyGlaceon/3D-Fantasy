using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtWaypoint : MonoBehaviour
{
    [SerializeField] CinemachineSmoothPath waypoint;
    [SerializeField] CinemachineVirtualCamera camera;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var dolly = camera.GetCinemachineComponent<CinemachineTrackedDolly>();

        Vector3 position = waypoint.m_Waypoints[(int)dolly.m_PathPosition].position;

        transform.InverseTransformVector(position);

        transform.LookAt(position);


        Debug.Log(waypoint.m_Waypoints[(int)dolly.m_PathPosition].position);
    }
}

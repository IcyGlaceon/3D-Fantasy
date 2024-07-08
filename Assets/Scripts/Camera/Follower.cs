using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class Follower : MonoBehaviour
{
    [SerializeField]Transform objectTransform;

    [SerializeField] Camera cam;

    [SerializeField] Transform playerTransform;

    [SerializeField]CinemachineSmoothPath path;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = objectTransform.position;

        //transform.position = cam.transform.forward;

        Debug.Log(cam.transform.forward);


        if (playerTransform.position.z >= path.m_Waypoints[8].position.z) Debug.Log("TURN");

        //path.m_Waypoints[8].
    }
}

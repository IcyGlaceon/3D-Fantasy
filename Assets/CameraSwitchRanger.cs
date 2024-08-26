using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitchRanger : MonoBehaviour
{
    [SerializeField] CinemachineSmoothPath dollyTrack;
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] CinemachineTargetGroup TargetGroup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Little Guy")
        {
            virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>().m_Path = dollyTrack;
            TargetGroup.AddMember(other.transform, 10, 1);
        }
    }
}

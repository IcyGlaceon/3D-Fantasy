using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    void Update()
    {
        
    }

    public static void SwitchPlayer(Movement pEnableController, Movement pDisableController)
    {
        pEnableController.enabled = true;
        pDisableController.enabled = false;
    }
}

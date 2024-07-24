using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class RangerClass : MonoBehaviour
{
    [SerializeField] GameObject LittleGuy;
    [SerializeField] Transform spawnPoint;

    private PlayerInput playerInput;

    private void Start()
    {
        playerInput = GetComponentInParent<PlayerInput>();
    }

    /* Things Done
     *  - Little Guy Spawns
     *  
     * Things to Be Done
     *  - Changing control from Player Char -> Little Guy
     *  - Little Guy can move around
     * 
     */


    void Update()
    {
        if (LittleGuy != null)
        {
            if (playerInput.actions["Ability"].WasPressedThisFrame())
            {
                SpawnThatGuy();
            }
        }

    }

    void SpawnThatGuy()
    {
        if (!GameObject.FindGameObjectWithTag("Little Guy"))
        {       
            Instantiate(LittleGuy, spawnPoint.position, Quaternion.identity * spawnPoint.rotation);
        }
        else
        {
            Destroy(GameObject.FindGameObjectWithTag("Little Guy"));
        }
    }
}

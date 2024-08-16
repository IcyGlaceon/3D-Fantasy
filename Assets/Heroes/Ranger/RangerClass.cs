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
    private GameObject guy;

    private void Start()
    {
        //playerInput = GetComponentInParent<PlayerInput>();
        //PlayerSwitch.Instance.AddCharacter(gameObject.transform.parent.gameObject.transform);
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
        //if (LittleGuy != null)
        //{
        //    if (playerInput.actions["Ability"].WasPressedThisFrame())
        //    {
        //        SpawnThatGuy();
        //    }
        //}

    }

    public void SpawnThatGuy(PlayerController controllingPlayer, int currentIndex)
    {
        if (!GameObject.FindGameObjectWithTag("Little Guy"))
        {       
            Instantiate(LittleGuy, spawnPoint.position, Quaternion.identity * spawnPoint.rotation);
            guy = GameObject.FindGameObjectWithTag("Little Guy");
            controllingPlayer.swapDisabled = true;
            controllingPlayer.currentCharacter = guy;
            

            //PlayerSwitch.Instance.AddCharacter(guy.transform);
        }
        else
        {
            //PlayerSwitch.Instance.possibleChracters.Remove(guy.transform);
            controllingPlayer.currentCharacter = controllingPlayer.availableCharacters[currentIndex];
            controllingPlayer.swapDisabled = false;
            Destroy(GameObject.FindGameObjectWithTag("Little Guy"));
        }
    }
}

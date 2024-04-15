using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FighterClass : MonoBehaviour
{
    public bool shieldAbility = false; //can hold ability button to pivot and redirect light 
    public bool strengthAbility = false;
    bool strengthHolding = false; //checks if the player is holding a strength object

    private PlayerInput playerInput;

    private void Start()
    {
        playerInput = GetComponentInParent<PlayerInput>();
    }

    public void Update()
    {
        if (playerInput.actions["Ability"].IsPressed() && GetComponentInParent<Movement>().controller.velocity == Vector3.zero) Ability();
       
    }

    //current error that happens when moving and trying to place down the strenght object

    public void Ability()
    {
        GameObject currentInteractable = GetComponentInParent<Player>().interactable;
        bool CanAbility = GetComponentInParent<Player>().canUseAbility;
        Debug.Log("Pressed the button");
        if (strengthAbility)
        {
            Strength(currentInteractable, CanAbility);
        }

        if (shieldAbility)
        {
            //pivot in place


        }
        
    }


    public void Strength(GameObject currentInteract, bool AbilityUsage)
    {
        if (!strengthHolding)
        {
            if (AbilityUsage)
            {
                currentInteract.transform.parent.SetParent(transform);
                strengthHolding = true;
            }
        }
        else
        {
            currentInteract.transform.parent.SetParent(null);
            strengthHolding = false;
        }
    }
}
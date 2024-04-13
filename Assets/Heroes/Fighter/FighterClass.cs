using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterClass : MonoBehaviour
{
    public bool shieldAbility = false; //can hold ability button to pivot and redirect light 

    public void Update()
    {
        //if (Input.GetButtonDown("Ability")) Ability();
        if (Input.GetButtonDown("Ability")) Strength();
    }

    public void Ability()
    {
        GameObject currentInteractable = GetComponent<Player>().interactable;
        bool CanAbility = GetComponent<Player>().canUseAbility;
        Debug.Log("Pressed the button");
        if (CanAbility)
        {
            currentInteractable.GetComponent<Interactable>().OnInteract();
        }
    }

    public void Strength()
    {

    }
}
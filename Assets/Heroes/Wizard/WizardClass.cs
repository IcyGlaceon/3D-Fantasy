using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardClass : MonoBehaviour
{
    public bool fireAbility = false;



    public void Update()
    {
        if (Input.GetButtonDown("Ability")) Ability();
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

}

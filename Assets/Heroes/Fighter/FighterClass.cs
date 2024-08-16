using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FighterClass : MonoBehaviour
{
    public bool shieldAbility = false; //can hold ability button to pivot and redirect light 
    public bool strengthAbility = false;
    public bool strengthHolding = false; //checks if the player is holding a strength object

    [SerializeField] private float forceMagnitude;

    public GameObject strengthObj;

    private PlayerInput playerInput;

    private void Start()
    {
        playerInput = GetComponentInParent<PlayerInput>();
        //PlayerSwitch.Instance.AddCharacter(gameObject.transform.parent.gameObject.transform);
    }

    public void FixedUpdate()
    {
        //if (playerInput.actions["Ability"].IsPressed() && GetComponentInParent<PlayerMovement>().characterController.velocity == Vector3.zero) Ability();
    }

    //current error that happens when moving and trying to place down the strenght object

    public void Ability()
    {
        if (GetComponentInParent<PlayerMovement>().characterController.velocity == Vector3.zero)
        {
            GameObject currentInteractable = GetComponentInParent<Player>().interactable;
            bool CanAbility = GetComponentInParent<Player>().canUseAbility;
            Debug.Log("Pressed the button");
            if (strengthAbility)
            {
                Strength(CanAbility, strengthObj);
            }
        }
        /* if (shieldAbility)
         {
             //pivot in place


         }*/

    }


    public void Strength(bool AbilityUsage, GameObject strengthObj)
    {
        if (!strengthHolding)
        {
            if (AbilityUsage)
            {
                strengthObj.transform.parent.SetParent(transform);
                strengthHolding = true;
            }
        }
        else
        {
            strengthObj.transform.parent.SetParent(null);
            strengthHolding = false;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;

        if (rb != null)
        {
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();

            rb.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);
        }
    }
}
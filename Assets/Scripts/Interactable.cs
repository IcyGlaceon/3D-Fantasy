using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    //[SerializeField] private GameObject interactionRange;
    [SerializeField] public Abilites required;
    public enum Abilites
    {
        Lightning,
        Fire,
        Strength,
        Lockpick,
        Shield,
        Agility
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Player>().interactable = this.gameObject;

            CheckCharacter(other.gameObject);
        }
    }

    private void CheckCharacter(GameObject other)
    {
        switch (required)
        {
            case Abilites.Lightning: //Wizard
                if (other.GetComponent<WizardClass>() != null)
                {
                    Debug.Log("Lightning");
                    other.GetComponent<Player>().canUseAbility = true;
                }
                break;
            case Abilites.Fire: //Wizard
                if (other.GetComponent<WizardClass>() != null)
                {
                    if (other.GetComponent<WizardClass>().fireAbility == true)
                    {
                        Debug.Log("Fire");
                        other.GetComponent<Player>().canUseAbility = true;
                    }
                    else Debug.Log("Wizard but fireless");
                }
                break;
            case Abilites.Strength: //Fighter
                if(other.GetComponent<FighterClass>() != null)
                {
                    Debug.Log("STRONG");
                    other.GetComponent<Player>().canUseAbility = true;
                }
                break;
            case Abilites.Shield: //Fighter
                if (other.GetComponent<FighterClass>() != null)
                {
                    if (other.GetComponent<FighterClass>().shieldAbility == true)
                    {
                        Debug.Log("Shield");
                        other.GetComponent<Player>().canUseAbility = true;
                    }
                    else Debug.Log("Fighter shieldless");
                }
                break;
            case Abilites.Agility: //Ranger?
                break;
            case Abilites.Lockpick: //Rouge
                break;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Player>().interactable = null;
            other.GetComponent<Player>().canUseAbility = false;
        }
    }

    public void OnInteract()
    {
        Debug.Log("Interacted");
    }


}

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
            case Abilites.Lightning:
                if (other.GetComponent<WizardClass>() != null)
                {
                    Debug.Log("Lightning");
                    other.GetComponent<Player>().CanAbility = true;
                }
                break;
            case Abilites.Fire:
                if (other.GetComponent<WizardClass>() != null)
                {
                    if (other.GetComponent<WizardClass>().hasFire == true)
                    {
                        Debug.Log("Fire");
                        other.GetComponent<Player>().CanAbility = true;
                    }
                    else Debug.Log("Wizard but fireless");
                }
                break;
            case Abilites.Strength:
                break;
            case Abilites.Agility:
                break;
            case Abilites.Shield:
                break;
            case Abilites.Lockpick:
                break;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Player>().interactable = null;
            other.GetComponent<Player>().CanAbility = false;
        }
    }

    public void OnInteract()
    {
        Debug.Log("Interacted");
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthPickup : MonoBehaviour
{
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
        if (other.tag == "Player")
        {
            other.GetComponentInChildren<FighterClass>().strengthAbility = true; //lets the player use the strength ability while touching a strength object
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.GetComponent<Interactable>() != null)
        {
            Debug.Log("Object in strength zone");
        }

        if (other.tag == "Player")
        {
            //other.GetComponentInChildren<FighterClass>().isInSrength = true; 
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //other.GetComponentInChildren<FighterClass>().isInSrength = false;
        }
    }

}

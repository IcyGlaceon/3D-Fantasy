using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthPickup : MonoBehaviour
{
    Vector3 strZonePos;
    bool Held = false;

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
            //lets the player use the strength ability while touching a strength object
            other.GetComponentInChildren<FighterClass>().strengthAbility = true;


            other.GetComponentInChildren<FighterClass>().strengthObj = gameObject;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Held = other.GetComponentInChildren<FighterClass>().strengthHolding;

        }

        if (other.gameObject.GetComponent<Interactable>() != null && !Held)
        {
            strZonePos = other.transform.position;
            Debug.Log("Object in strength zone");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            transform.SetPositionAndRotation(strZonePos, transform.rotation);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            OnPickup(collision.gameObject); 
        }
    }


    virtual public void OnPickup(GameObject player)
    {

    }
}

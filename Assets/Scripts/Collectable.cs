using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
            OnPickup(collision.gameObject);
        }
    }

    virtual public void OnPickup(GameObject gameObject)
    {

    }
}

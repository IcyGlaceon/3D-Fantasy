using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PushableObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //figure out how the fuck to move the box

            //Debug.Log(collision.gameObject.GetComponent<Movement>().controller.velocity.normalized);
            //transform.Translate(Vector3.forward * collision.gameObject.transform.rotation.normalized.y);
        }
    }
}

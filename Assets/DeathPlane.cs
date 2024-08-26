using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
        Debug.Log(other.gameObject.tag);

        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().health -= 100;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

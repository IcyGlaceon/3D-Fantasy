using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCollectible : MonoBehaviour
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
        if(other.tag == "Player")
        {
            Debug.Log("AH");
            other.GetComponentInChildren<FighterClass>().shieldAbility = true;
            //other.GetComponent<FighterClass>().shieldAbility = true;

        }
    }
}

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
            other.GetComponentInChildren<FighterClass>().shieldAbility = true;

            transform.SetParent(other.transform.Find("ShieldHolder"));

            transform.SetPositionAndRotation(other.transform.Find("ShieldHolder").position, Quaternion.Euler(0, 0, 0));
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class StaffProjectile : MonoBehaviour
{

    float DeathTimer = 3;

    void Update()
    {
        if (DeathTimer > 0)
        {
            DeathTimer -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }


}

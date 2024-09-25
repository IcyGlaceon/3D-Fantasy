using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Collectable
{

    [SerializeField] public int healing = 50;

    public override void OnPickup(GameObject player)
    {
        player.GetComponent<Player>().health += healing;
        Destroy(gameObject);
    }
}

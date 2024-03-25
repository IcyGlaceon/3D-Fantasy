using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : Collectable
{
    [SerializeField] public int value = 100;


    public override void OnPickup(GameObject player)
    {
        player.GetComponent<Player>().money += value;
        Destroy(gameObject);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int money = 0;
    public int health = 0;
    public GameObject interactable;
    public bool CanAbility = false;


    public void OnDeath()
    {
        if (money < 1000) money = 0;
        else money -= 1000;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public int money = 0;
    public int health = 0;
    public GameObject interactable;
    public bool canUseAbility = false;
    public string className = "Default";

    public GameObject playerManager;

    private PlayerInput input;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
    }

    public void OnEnable()
    {
        GetComponent<PlayerInput>().enabled = true;        
    }

    public void OnDisable()
    {
        GetComponent<PlayerInput>().enabled = false;
    }

    public void OnDeath()
    {
        if (money < 1000) money = 0;
        else money -= 1000;
    }

    public void OnSwitch()
    {
        playerManager.GetComponent<PlayerManager>().SwapCharacter();
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LittleGuyScript : MonoBehaviour
{
    Movement movement;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponentInParent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Swap(Movement inMovement)
    {
        PlayerSwitch.SwitchPlayer(movement, inMovement);
    }
}

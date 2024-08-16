using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public List<GameObject> availableCharacters;

    private PlayerInput playerInput;
    public GameObject currentCharacter;
    public int index = 0;

    public bool swapDisabled = false;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        availableCharacters = GameObject.FindGameObjectsWithTag("Player").ToList();
        FindAvailablePlayer(index);
        currentCharacter.GetComponent<PlayerMovement>().enabled = true;
        currentCharacter.GetComponent<PartnerAI>().enabled = false;
    }

    void OnMove(InputValue direction)
    {
        currentCharacter.GetComponent<PlayerMovement>().inputVector = direction.Get<Vector2>();
    }

    void OnJump()
    {
        currentCharacter.GetComponent<PlayerMovement>().JumpPlayer();
    }

    void OnSwitch()
    {
        if (!swapDisabled)
        {
            currentCharacter.GetComponent<PlayerMovement>().enabled = false;
            currentCharacter.GetComponent<PartnerAI>().enabled = true;
            NextIndex(index);
            FindAvailablePlayer(index);
            currentCharacter.GetComponent<PlayerMovement>().enabled = true;
            currentCharacter.GetComponent<PartnerAI>().enabled = false;
        }
    }

    void OnFire()
    {
        if (currentCharacter.GetComponentInChildren<MeleeAttack>())
        {
            currentCharacter.GetComponentInChildren<MeleeAttack>().Attack();
        }
    }

    void OnAbility()
    {
        if (currentCharacter.GetComponent<FighterClass>())
        {
            currentCharacter.GetComponent<FighterClass>().Ability();
        }
        if (currentCharacter.GetComponent<RangerClass>() || currentCharacter.CompareTag("Little Guy"))
        {
            availableCharacters[index].GetComponent<RangerClass>().SpawnThatGuy(this, index);
        }
    }

    void FindAvailablePlayer(int currentIndex)
    {
        Debug.Log(currentIndex);
        if (!availableCharacters[currentIndex].GetComponent<PlayerMovement>().enabled)
        {
            currentCharacter = availableCharacters[currentIndex];
        }
        else
        {
            NextIndex(currentIndex);
            FindAvailablePlayer(index);
        }
    }

    void NextIndex(int currentIndex)
    {
        if (currentIndex >= availableCharacters.Count - 1)
        {
            index = 0;
        }
        else
        {
            index++;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

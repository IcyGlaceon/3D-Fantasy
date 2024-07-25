using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSwitch : MonoBehaviour
{
    public static PlayerSwitch Instance { get; private set; }

    [SerializeField] public Transform character;
    [SerializeField] public List<Transform> possibleChracters;
    [HideInInspector] public int whichCharacter = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (character == null && possibleChracters.Count >= 1)
        {
            character = possibleChracters[0];
        }
        Swap();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            if (whichCharacter == 0)
            {
                whichCharacter = possibleChracters.Count - 1;
            }
            else
            {
                whichCharacter -= 1;
            }
            Swap();
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (whichCharacter == possibleChracters.Count - 1)
            {
                whichCharacter = 0;
            }
            else
            {
                whichCharacter += 1;
            }
            Swap();
        }
    }

    public void Swap()
    {
        character = possibleChracters[whichCharacter];
        character.GetComponent<PlayerMovement>().enabled = true;
        character.GetComponent<PlayerInput>().enabled = true;
        for (int i = 0; i < possibleChracters.Count; i++)
        {
            if (possibleChracters[i] != character)
            {
                possibleChracters[i].GetComponent<PlayerMovement>().enabled = false;
                possibleChracters[i].GetComponent<PlayerInput>().enabled = false;
            }
        }
    }

    public void AddCharacter(Transform character)
    {
        Instance.possibleChracters.Add(character);
        if (character == null && possibleChracters.Count >= 1)
        {
            character = possibleChracters[whichCharacter];
        }
        Swap();
    }

}

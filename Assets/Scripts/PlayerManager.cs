using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerManager : MonoBehaviour
{

    [SerializeField] private GameObject character1;
    [SerializeField] private GameObject character2;

    public int PlayerNumber = 1;

    //[SerializeField] private GameObject 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwapCharacter()
    {
        if (character1.activeSelf)
        {
            character2.transform.position = character1.transform.position;
            character1.SetActive(false);
            character2.SetActive(true);
            gameObject.GetComponent<Player>().className = character2.name;
            GetComponent<PlayerMovement>().characterController = character2.GetComponent<CharacterController>();
        }
        else if (character2.activeSelf)
        {
            character1.transform.position = character2.transform.position;
            character2.SetActive(false);
            character1.SetActive(true);
            gameObject.GetComponent<Player>().className = character1.name;
            GetComponent<PlayerMovement>().characterController = character1.GetComponent<CharacterController>();

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartnerAI : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] CharacterController characterController;

    float speed = 1.0f;

    Vector3 direction = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        direction = player.GetComponent<PlayerManager>().currentCharacter.transform.position - gameObject.transform.position;

        direction *= speed;

        characterController.Move(direction * Time.deltaTime);
    }
}

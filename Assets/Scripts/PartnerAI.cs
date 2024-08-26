using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PartnerAI : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] CharacterController characterController;
    [SerializeField] NavMeshAgent agent;

    public Animator animator;

    float speed = 1.0f;

    Vector3 direction = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        //player = FindObjectOfType<PlayerController>().currentCharacter;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(agent.velocity.magnitude);
        if (animator && agent.velocity.magnitude > 1) animator.SetBool("IsWalking", true);
        else if (animator) animator.SetBool("IsWalking", false);
        agent.SetDestination(player.transform.position);
        //direction = player.transform.position - gameObject.transform.position;

        //direction *= speed;

        //characterController.Move(direction * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private int MaxHealth = 50;
    public int CurrentHealth;

    [SerializeField] int MoneyDrop;
    [SerializeField] float DeathTimer = 3f;

    [SerializeField] GameObject hitbox;

    NavMeshAgent agent;

    private Animator animator;

    private List<GameObject> players;
    private GameObject currentPlayer;

    private CharacterController characterController;

    private bool isInterupted = false;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponentInParent<NavMeshAgent>();
        players = GameObject.FindGameObjectsWithTag("Player").ToList();
        currentPlayer = players[0];
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude);
        if (CurrentHealth <= 0)
        {
            agent.updatePosition = false;
            OnDead();
        }
    }

    void LateUpdate()
    {
        float minDist = 0;
        foreach (GameObject player in players)
        {
            float distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
            if (distance > minDist)
            {
                minDist = distance;
                currentPlayer = player;
                agent.destination = currentPlayer.transform.position;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Attack();
        }
    }

    void Attack()
    {
        agent.updatePosition = false;
        Debug.Log("Attacked");
        animator.SetTrigger("Attack");
        agent.updatePosition = true;

    }

    void OnDead()
    {
        Debug.Log("Goober has perished");
        animator.SetTrigger("IsDead");
        Invoke("Death", DeathTimer);
        
    }

    void Death()
    {
        Destroy(gameObject);
    }

    public void OnAttack()
    {
        hitbox.GetComponent<EnemyHitBox>().OnAttack();
    }
    
    //public void AttackEnd()
    //{
        
    //}

}

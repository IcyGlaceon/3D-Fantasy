using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private int MaxHealth = 50;
    public int CurrentHealth;

    [SerializeField] int MoneyDrop;

    private List<GameObject> players;
    private GameObject currentPlayer;

    private CharacterController characterController;

    private bool isInterupted = false;

    // Start is called before the first frame update
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        players = GameObject.FindGameObjectsWithTag("Player").ToList();
        currentPlayer = players[0];
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInterupted)
        {
            Vector3 direction = currentPlayer.transform.position - gameObject.transform.position;
            characterController.Move(direction * Time.deltaTime);
        }
        if (CurrentHealth <= 0)
        {
            isInterupted = true;
            Death();
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
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //StartCoroutine("Attack");
            Attack();
        }
    }

    void Attack()
    {
        isInterupted = true;
        Debug.Log("Attacked");
        isInterupted = false;
        //yield return null;
    }

    void Death()
    {
        Debug.Log("Goober has perished");
        Destroy(gameObject);
    }

}

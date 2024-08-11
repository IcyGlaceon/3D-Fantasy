using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHitBox : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] int damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Player>().health -= damage;
            Debug.Log(other.GetComponent<Player>().health);
        }
    }

    public void OnAttack()
    {
        if (gameObject.activeSelf == false)
        {
            gameObject.SetActive(true);
            agent.updatePosition = false;
        }
        else
        {
            gameObject.SetActive(false);
            agent.updatePosition = true;
        }
    }
}

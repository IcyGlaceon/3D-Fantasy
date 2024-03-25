using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public MeleeAttack ma;
    public GameObject hitParticle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && ma.IsAttacking)
        {
            Debug.Log(other.name);

            //other.GetComponent<Animator>().SetTrigger("Hit");

            //Instantiate(hitParticle, new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), other.transform.rotation);

        }
        if (other.tag == "Breakable" && ma.IsAttacking)
        {
            Debug.Log(other.name);
            other.GetComponent<Breakable>().OnBreak();
        }
    }
}

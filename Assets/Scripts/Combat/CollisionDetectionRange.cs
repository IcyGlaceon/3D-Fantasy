using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectionRange : MonoBehaviour
{
    [SerializeField] GameObject hitParticle;
    [SerializeField] public RangeAttack ra;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && ra.IsAttacking)
        {
            Debug.Log(other.name);
            Destroy(gameObject);

            //other.GetComponent<Animator>().SetTrigger("Hit");

            //Instantiate(hitParticle, new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), other.transform.rotation);

        }
        if (other.tag == "Breakable" && ra.IsAttacking)
        {
            Debug.Log(other.name);
            other.GetComponent<Breakable>().OnBreak();
            Destroy(gameObject);
        }
        if (other.tag == "Ground" && ra.IsAttacking)
        {
            Debug.Log(other.name);
            Destroy(gameObject);
        }
    }
}

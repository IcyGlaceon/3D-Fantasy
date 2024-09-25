using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class ExplosiveBarrel : MonoBehaviour
{
    float fuseTimer = 3.0f;
    [SerializeField] GameObject explosiveRadius;
    [SerializeField] private bool delayed = false;

    public void Update()
    {

    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Fire"))
        {
            if (delayed) OnIgnite();
            else Explode();
        }
    }

    public void OnIgnite()
    {
        Debug.Log("Ignited");
    }

    public void Explode()
    {
        Instantiate(explosiveRadius);
        Debug.Log("Boom");
        Destroy(gameObject);
    }

}

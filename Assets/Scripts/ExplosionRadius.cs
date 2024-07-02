using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionRadius : MonoBehaviour
{
    float persistTimer = 0.1f;

    private void Update()
    {
        persistTimer -= Time.deltaTime;
        if (persistTimer < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Explodable"))
        {
            other.gameObject.GetComponent<Breakable>().OnBreak();
        }
    }
}

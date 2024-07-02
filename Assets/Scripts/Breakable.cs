using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    [SerializeField] private bool dropHealth = true;

    [SerializeField] public int value = 500;
    [SerializeField] public GameObject health;
    [SerializeField] public GameObject money;

    public void OnBreak()
    {
        float spawnHealth = Random.value;
        money.GetComponent<Money>().value = value;
        Debug.Log(spawnHealth);
        if (dropHealth && spawnHealth >= 0.75)
        {
            Instantiate(health);
        }
        Instantiate(money);
        Destroy(gameObject);
    }

}

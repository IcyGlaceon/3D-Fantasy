using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    [SerializeField] public int value = 500;
    [SerializeField] public GameObject money;

    public void OnBreak()
    {
        money.GetComponent<Money>().value = value;
        Instantiate(money);
        Destroy(gameObject);
    }

}

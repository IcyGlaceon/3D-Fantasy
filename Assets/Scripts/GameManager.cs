using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Player player1 = null;
    [SerializeField] Player player2 = null;

    [SerializeField] TextMeshProUGUI player1Health;
    [SerializeField] TextMeshProUGUI player1Money;
    [SerializeField] TextMeshProUGUI player1Name;

    [SerializeField] TextMeshProUGUI player2Health;
    [SerializeField] TextMeshProUGUI player2Money;
    [SerializeField] TextMeshProUGUI player2Name;

    [SerializeField] GameObject otherCharacter;

    // Start is called before the first frame update
    void Start()
    {
        if (player1 != null)
        {
            player1Health.text = player1.health.ToString();
            player1Money.text = player1.money.ToString();
            player1Name.text = player1.className.ToString();
        }

        if (player2 != null)
        {
            player2Health.text = player2.health.ToString();
            player2Money.text = player2.money.ToString();
            player2Name.text = player2.className.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DropInPlayer()
    {
        //otherCharacter.gameObject.
    }
}

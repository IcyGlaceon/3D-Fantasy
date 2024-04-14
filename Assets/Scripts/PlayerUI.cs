using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerHealth;
    [SerializeField] private TextMeshProUGUI playerMoney;
    [SerializeField] private UnityEngine.UI.Image playerIcon;
    [SerializeField] private GameObject playerCharacter;

    private void Update()
    {
        playerHealth.text = playerCharacter.GetComponent<Player>().health.ToString();
        playerMoney.text = playerCharacter.GetComponent<Player>().money.ToString();
    }




}

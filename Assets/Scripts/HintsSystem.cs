using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;

public class HintsSystem : MonoBehaviour
{
    [TextArea(10, 20)]
    [SerializeField] string HintText;
    [SerializeField] float hintDelay;
    [SerializeField] TextMeshProUGUI hintGUI;

    private bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !activated)
        {
            hintGUI.text = HintText;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Invoke("RemoveText", hintDelay);
    }

    private void RemoveText()
    {
        hintGUI.text = "";
        activated = true;
    }


}

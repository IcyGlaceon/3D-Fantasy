using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AreaTransition : MonoBehaviour
{
    [SerializeField] GameObject areaA;
    [SerializeField] GameObject areaB;

    [SerializeField] GameObject trigger;
    [SerializeField] GameObject playerPos;
    [SerializeField] GameObject cameraPos;

    private List<GameObject> players;

    private void Awake()
    {
        players = GameObject.FindGameObjectsWithTag("Player").ToList();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            LoadArea();
        }
    }

    private void LoadArea()
    {
        areaB.SetActive(true);
        foreach (GameObject player in players)
        {
            Debug.Log(playerPos.transform.position);
            player.GetComponent<PlayerMovement>().enabled = false;
            player.gameObject.transform.position = playerPos.transform.position;
        }
        Invoke("SetControl", 0.1f);
        Camera.main.transform.position = cameraPos.transform.position;
        areaA.SetActive(false);
    }

    private void SetControl()
    {
        foreach (GameObject player in players)
        {
            player.GetComponent<PlayerMovement>().enabled = true;
        }
    }

}

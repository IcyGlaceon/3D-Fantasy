using Cinemachine;
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
    [SerializeField] CinemachineSmoothPath dollyTrack;

    [SerializeField] CinemachineVirtualCamera virtualCamera;

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
            //player.GetComponent<PlayerMovement>().enabled = false;
            //player.GetComponent<PartnerAI>().enabled = false;

            //if (player.GetComponent<PlayerMovement>().enabled)
            //{
            //    player.GetComponent<PlayerMovement>().enabled = false;
            //    StartCoroutine(SetControl(player));

            //}
            //if (player.GetComponent<PartnerAI>().enabled)
            //{
            //    player.GetComponent<PartnerAI>().enabled = false;
            //    StartCoroutine(SetAI(player));
            //}
            player.SetActive(false);
            player.transform.position = playerPos.transform.position;
            player.SetActive(true);

        }
        //Invoke("SetControl", 0.1f);

        virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>().m_Path = dollyTrack;

        areaA.SetActive(false);
    }

    private IEnumerator SetControl(GameObject player)
    {
        player.GetComponent<PlayerMovement>().enabled = true;
        yield return new WaitForSeconds(1f);
    }

    private IEnumerator SetAI(GameObject player)
    {
        player.GetComponent<PartnerAI>().enabled = true;
        yield return new WaitForSeconds(1f);
    }

}

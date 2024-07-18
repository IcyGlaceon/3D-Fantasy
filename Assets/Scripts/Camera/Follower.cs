using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class Follower : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    [SerializeField] CinemachineSmoothPath waypoint;

    [SerializeField] Transform playerTransform;

    public float speed = 5.0f;
    public float followDistance = 2.0f;

    private int currentWaypointIndex = 0;

    // Update is called once per frame
    void Update()
    {
        if (currentWaypointIndex < waypoint.m_Waypoints.Length)
        {


            /*Vector3 targetWaypoint = new Vector3()// waypoint.transform.TransformDirection(waypoint.m_Waypoints[currentWaypointIndex].position);
            Vector3 directionToWaypoint = (targetWaypoint - transform.position).normalized;
*/

            Transform targetWaypoint = waypoints[currentWaypointIndex];

            Vector3 direction = targetWaypoint.position - transform.position;

            


            // Check if we've reached the waypoint
            if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
            {
                Debug.Log("HIT");
                currentWaypointIndex++;
            }
            else
            {
                transform.position += direction.normalized * speed * Time.deltaTime;
            }
        }

        // Follow the player at a fixed distance
        Vector3 followPosition = playerTransform.position - playerTransform.forward * followDistance;
        transform.position = new Vector3(followPosition.x, transform.position.y, followPosition.z);



        transform.LookAt(playerTransform);
    }
}

using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class Follower : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    [SerializeField] Transform playerTransform;

    public float speed = 5.0f;
    public float followDistance = 2.0f;

    private int currentWaypointIndex = 0;

    // Update is called once per frame
    void Update()
    {
        if (currentWaypointIndex < waypoints.Length)
        {
            Transform targetWaypoint = waypoints[currentWaypointIndex];
            Vector3 directionToWaypoint = (targetWaypoint.position - transform.position).normalized;

  
            Vector3 playerDirection = playerTransform.forward;
            Vector3 desiredPosition = playerTransform.position - playerDirection * followDistance;

            Vector3 movement = Vector3.MoveTowards(transform.position, desiredPosition, speed * Time.deltaTime);
            transform.position = new Vector3(movement.x, transform.position.y, movement.z);

            if(Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
            {
                currentWaypointIndex++;
            }
        }


        transform.LookAt(playerTransform);
    }
}

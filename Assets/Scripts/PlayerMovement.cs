using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public GameObject groundCheckTransform;

    public float speed = 5f;
    public float jumpPower = 1f;
    public float gravity = -1f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    Vector3 direction = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (controller.isGrounded && direction.y < 0) direction.y = 0f;

        if (Input.GetButtonDown("Jump") && Physics.Raycast(groundCheckTransform.transform.position, Vector3.down, 1))
        {
            direction.y = Mathf.Sqrt(jumpPower * -3 * gravity);
            Debug.Log("Ground");
        }
        
        direction = new Vector3(horizontal, direction.y, vertical);

        //makes the player rotate when moving left or right
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        //applys gravity
        direction.y += gravity * Time.deltaTime;

        controller.Move(speed * Time.deltaTime * direction);
    }
}

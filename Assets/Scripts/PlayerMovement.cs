using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public GameObject groundCheckTransform;

    private PlayerInput playerInput;

    public float jumpPower = 1f;
    public float gravity = -1f;
    public float slowMovement = 1f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    Vector3 direction = Vector3.zero;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        direction.x = playerInput.actions["Move"].ReadValue<Vector2>().x;
        direction.z = playerInput.actions["Move"].ReadValue<Vector2>().y;


        //controller.Move(direction);
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded && direction.y < 0) direction.y = 0f;

         if (playerInput.actions["Jump"].IsPressed() && Physics.Raycast(groundCheckTransform.transform.position, Vector3.down, 0.1f))
         {
             direction.y = Mathf.Sqrt(jumpPower * -4 * gravity);
             //Debug.Log("Ground");
         }

         //makes the player rotate when moving left or right
         float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
         float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
         transform.rotation = Quaternion.Euler(0f, angle, 0f);

         //applys gravity
         direction.y += gravity * Time.deltaTime;

        controller.Move(direction / slowMovement);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public GameObject groundCheckTransform;

    private PlayerInput playerInput;

    InputAction moveAction;
    InputAction jumpAction;

    public float jumpPower = 1f;
    public float gravity = -1f;
    public float slowMovement = 1f;

    public float speed = 1f;

    public float turnSmoothTime = 0.1f;

    public Transform cameraTransform;
    float turnSmoothVelocity;

    Vector3 movement = Vector3.zero;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
        jumpAction = playerInput.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        //Reads in movement input
        Vector2 direction = moveAction.ReadValue<Vector2>();

        movement = new Vector3(direction.x, 0, direction.y);

        movement = cameraTransform.TransformDirection(movement);
        movement *= speed * Time.deltaTime;

        //Debug.Log(movement);

        //Allows player to rotate
        float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;


        if (direction.y == 1)
        {
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }

        if (targetAngle != 0)
        {
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
        //

        //Does jumping
        if (jumpAction.IsPressed() && Physics.Raycast(groundCheckTransform.transform.position, Vector3.down, 0.1f))
        {
            Jump();
        }
        //

        //Apply Gravity
        movement.y += gravity * Time.deltaTime;


        //Moves player
        controller.Move(movement);
    }

    void Jump()
    {
        movement.y = Mathf.Sqrt(jumpPower * -4 * gravity);
    }
}

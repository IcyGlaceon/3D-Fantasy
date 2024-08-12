using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    InputAction moveAction;
    InputAction jumpAction;
    public Animator animator;

    [Header("Player Movement")]
    public CharacterController characterController;
    [HideInInspector]public Transform cameraTransform;
    public float speed = 5.0f;

    [Header("Player Rotate")] 
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    [Header("Player Jump")]
    public GameObject groundCheckTransform;
    public float jumpPower = 1f;
    private Vector3 velocity;
    public float gravity = 1f;

    private void Awake()
    {
        playerInput = GetComponentInChildren<PlayerInput>(); //GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
        jumpAction = playerInput.actions.FindAction("Jump");
    }


    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = moveAction.ReadValue<Vector2>();
        Vector3 moveDirection = new Vector3(inputVector.x, 0, inputVector.y);
        JumpPlayer(moveDirection);
        
        MovePlayer(moveDirection);

        if (inputVector == Vector2.zero) animator.SetBool("IsWalking", false);

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    private void MovePlayer(Vector3 moveDirection)
    {
        if(moveDirection.sqrMagnitude > 0.01f)
        {
            Vector3 cameraForward = cameraTransform.forward;
            Vector3 cameraRight = cameraTransform.right;

            cameraForward.y = 0;
            cameraRight.y = 0;

            cameraForward.Normalize();
            cameraRight.Normalize();

            Vector3 direction = (cameraForward * moveDirection.z + cameraRight * moveDirection.x).normalized;
            RotatePlayer(direction);
            animator.SetBool("IsWalking", true);
            characterController.Move(direction * speed * Time.deltaTime);
        }
    }

    private void RotatePlayer(Vector3 direction)
    {
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        if (direction.normalized.z == 1 || direction.normalized.x == 1)
        {
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }

        if (targetAngle != 0)
        {
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
    }

    private void JumpPlayer(Vector3 direction)
    {
        //Debug.Log(Physics.Raycast(groundCheckTransform.transform.position, Vector3.down, 0.1f));    
        if (jumpAction.IsPressed() && Physics.Raycast(groundCheckTransform.transform.position, Vector3.down, 0.1f))
        {           
            Debug.Log("AH");
            velocity.y = Mathf.Sqrt(jumpPower * -4 * Physics.gravity.y);
            
        }
    }
}

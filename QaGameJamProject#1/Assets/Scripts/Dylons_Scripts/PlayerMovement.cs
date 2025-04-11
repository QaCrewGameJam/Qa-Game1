using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public bool isRunning;

    public float groundDrag;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public AudioSource walking;
    public AudioSource running;

    [Header("Input Actions")]
    [SerializeField] private InputActionAsset PlayerControls;

    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction sprintAction;
    public Vector2 moveInput;
    public Vector2 lookInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        moveAction = PlayerControls.FindActionMap("Player").FindAction("Move");
        lookAction = PlayerControls.FindActionMap("Player").FindAction("Look");
        sprintAction = PlayerControls.FindActionMap("Player").FindAction("Sprint");

        lookAction.performed += context => lookInput = context.ReadValue<Vector2>();
        lookAction.canceled += context => lookInput = Vector2.zero;
    }

    private void OnEnable()
    {
        moveAction.Enable();
        lookAction.Enable();
        sprintAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        lookAction.Disable();
        sprintAction.Disable();
    }

    private void Update()
    {
        myInput();

        rb.linearDamping = groundDrag;

        if(sprintAction.inProgress && verticalInput > 0)
        {
            moveSpeed = 10;
            isRunning = true;
        }
        else
        {
            moveSpeed = 5;
            isRunning = false;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void myInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);


        if(horizontalInput != 0 && isRunning == true || verticalInput != 0 && isRunning == true)
        {
            //running.Play();
        }
        else if (horizontalInput != 0 || verticalInput != 0)
        {
            //walking.Play();
        }
    }
}

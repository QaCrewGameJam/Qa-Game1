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


    [Header("Player Camera")]
    public GameObject playerCamera;

    public float mouseSens;
    public float controllerSens;

    float xRotation;
    float yRotation;

    [Header("Input Actions")]
    [SerializeField] private InputActionAsset PlayerControls;

    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction sprintAction;
    private Vector2 moveInput;
    private Vector2 lookInput;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

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

        if(sprintAction.inProgress)
        {
            moveSpeed = 10;
            isRunning = true;
        }
        else
        {
            moveSpeed = 5;
            isRunning = false;
        }


        // get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * mouseSens;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * mouseSens;

        // get all mouse/controllers input
        float mouseXRotation = lookInput.x * Time.deltaTime * mouseSens;
        float mouseYRotation = lookInput.y * Time.deltaTime * mouseSens;

        //yRotation += mouseX;
        //xRotation -= mouseY;
        xRotation -= mouseYRotation;
        yRotation += mouseXRotation;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // rotate cam and orientation
        playerCamera.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
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

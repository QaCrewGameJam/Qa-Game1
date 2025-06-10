using System;
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

    [Header("Audio")]
    [SerializeField] private AudioClip[] footStepAudio;
    [SerializeField] private AudioClip[] runningAudio;
    private AudioSource audioSource;
    public float FootStepFrequency = 10;
    public float RunningFrequency = 100;
    private float StepCounter;
    private bool Stepping;

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

        audioSource = GetComponent<AudioSource>();

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
            Run();
        }
        else if (horizontalInput != 0 || verticalInput != 0)
        {
            Step();
        }
    }

    private void Step()
    {
        StepCounter = Mathf.Sin(Time.time * FootStepFrequency);

        if (StepCounter > 0.97f && Stepping == false)
        {
            Stepping = true;
            AudioClip clip = GetRandomClip();
            audioSource.PlayOneShot(clip);
        }
        else if (Stepping == true && StepCounter < -0.97f)
        {
            Stepping = false;
        }
    }

    private AudioClip GetRandomClip()
    {
        return footStepAudio[UnityEngine.Random.Range(0, footStepAudio.Length)];
    }

    private void Run()
    {
        StepCounter = Mathf.Sin(Time.time * RunningFrequency);

        if (StepCounter > 0.97f && Stepping == false)
        {
            Stepping = true;
            AudioClip clip = GetRandomRunClip();
            audioSource.PlayOneShot(clip);
        }
        else if (Stepping == true && StepCounter < -0.97f)
        {
            Stepping = false;
        }
    }

    private AudioClip GetRandomRunClip()
    {
        return runningAudio[UnityEngine.Random.Range(0, runningAudio.Length)];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        myInput();

        rb.linearDamping = groundDrag;

        if(Input.GetKey(KeyCode.LeftShift) || Input.GetButton("Fire1"))
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] private PlayerMovement PlayerMovement_script;

    public float mouseSens;
    public float controllerSens;

    public Transform orientation;

    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // get mouse input (No longer needed)
        //float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * mouseSens;
        //float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * mouseSens;

        // get mouse/controller look inputs
        float lookXRotation = PlayerMovement_script.lookInput.x * Time.deltaTime * mouseSens;
        float lookYRotation = PlayerMovement_script.lookInput.y * Time.deltaTime * mouseSens;

        //yRotation += mouseX;
        //xRotation -= mouseY;
        yRotation += lookXRotation;
        xRotation -= lookYRotation;
        

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // rotate cam and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}

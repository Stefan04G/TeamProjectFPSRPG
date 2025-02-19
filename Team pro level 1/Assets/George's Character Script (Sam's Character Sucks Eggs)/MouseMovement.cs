using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
       public float mouseSensitivity = 100f;

       float xRotation = 0f;
       float yRotation = 0f;

       public float topClamp = 90f;
       public float bottomClamp = 90f;


    // Start is called before the first frame update
    void Start()
    {
        //locking the cursor to the middle of the screen and making it invisible
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //getting the mouse inputs
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //Rotation around the x axis (look up and down)
        xRotation -= mouseY;

        //clamp the Rotation
        xRotation = Mathf.Clamp(xRotation, 90f, 90f);

        //Rotation around the y axis (look left and right)
        yRotation += mouseX;

        //Apply the rotations to our transform
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        

    }
}

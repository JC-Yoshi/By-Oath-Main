using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;//locks the cursor to the center of the screen
        Cursor.visible = false;//makes the cursor invisable 
    }

     void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;//gets the mouse input for x
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;//gets the mouse input for y

        yRotation += mouseX;//prevents over rotation
        xRotation -= mouseY;//prevents over rotation

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);//clamps the players to 90 degrees


        transform.rotation=Quaternion.Euler(xRotation, yRotation, 0);//allows the camera rotation along x and y axis
        orientation.rotation = Quaternion.Euler(0, yRotation, 0); //lets the player rotate around the y axis


    }

}

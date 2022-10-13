using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;   

   
    void Start()
    {
        rb=GetComponent<Rigidbody>();  //gets the rigidBody attached to this component 
        rb.freezeRotation=true;//stops player from falling over
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        //calculate the movement direction
        moveDirection=orientation.forward*verticalInput+orientation.right* horizontalInput;

        rb.AddForce(moveDirection.normalized* moveSpeed * 10f, ForceMode.Force); 
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit the velocity if its to high 
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized*moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z); 
        }       

    }

    
    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl(); 
        // below code handles Drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0f;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
}

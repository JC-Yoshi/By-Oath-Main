using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    [Header("Movement")]
    public float moveSpeed;// max mopve speed

    public float groundDrag;//the amonut of drag the ground provides

    [Header("Ground Check")]
    public float playerHeight;//the players height
    public LayerMask whatIsGround;//defines what te ground is
    bool grounded;// yes on ground or no not on ground

    public Transform orientation;
    

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;//defines the direction to move in 

    Rigidbody rb;// provides acsses to the rigid body 

   
    void Start()
    {
        rb=GetComponent<Rigidbody>();  //gets the rigidBody attached to this component 
        rb.freezeRotation=true;//stops player from falling over
    }

    private void MyInput()// on input
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");//a and w key inputs 
        verticalInput = Input.GetAxisRaw("Vertical");//w and s inputs
    }

    private void MovePlayer()//moves the player 
    {
        //calculate the movement direction
        moveDirection=orientation.forward*verticalInput+orientation.right* horizontalInput;
        

        rb.AddForce(moveDirection.normalized* moveSpeed * 10f, ForceMode.Force); //applies calculated movement to the rigid body
    }

    private void SpeedControl()//controls the speed the player can reach
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);//calculates the velocity the player has

        //limit the velocity if its to high 
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized*moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z); 
        }       

    }

    
    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);// calculates if the player is on the ground

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

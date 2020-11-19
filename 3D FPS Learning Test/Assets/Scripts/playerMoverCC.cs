using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerMoverCC : MonoBehaviour
{
    public CharacterController controller;

    //public Transform player;


    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 0.0015f;

    Vector3 velocity;


    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public bool isGrounded;


    // Update is called once per frame
    void Update()
    {
        //Checks if player is on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        float z = Input.GetAxis("Horizontal");
        float x = Input.GetAxis("Vertical");

        Vector3 move = transform.right*z + transform.forward * x;

        //gravity code
        velocity.y += gravity * 0.075f * Time.deltaTime;
        if (isGrounded)
        {
            velocity.y = 0f;
        }


        controller.Move(move * speed * Time.deltaTime);

        //Jump code
     
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


        //Moves player on y-axis according to gravity and jump
        controller.Move(velocity);




    }
}
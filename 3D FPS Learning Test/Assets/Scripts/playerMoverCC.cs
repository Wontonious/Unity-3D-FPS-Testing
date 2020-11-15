using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerMoverCC : MonoBehaviour
{
    public CharacterController controller;

    public Transform playerCamera;
    public Transform player;


    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    Vector3 velocity;


    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool isGrounded;


    // Update is called once per frame
    void Update()
    {
        //Checks if player is on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move;
        //Vector3 move = transform.right*z + -transform.forward * x;
        move = transform.InverseTransformDirection(Vector3.forward*x + -Vector3.right*z);
        //move = transform.InverseTransformDirection(Vector3.right*z);


        controller.Move(move * speed * Time.deltaTime);

        //Jump code
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //gravity code
        velocity.y += gravity * Time.deltaTime;

        //player jump move code
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            controller.Move((velocity * Time.deltaTime) / 10);
        }
        else
        {
            controller.Move(velocity * Time.deltaTime);
        }

        //player move in facing direction


        player.transform.localRotation = Quaternion.Euler(0f, x, 0f);

       // private Vector3 TransformDirection(0f, z, 0f);

        /*
        if (Input.GetButtonDown(KeyCode.LeftControl)) //Shift -> sprint *doesn't work
        {
            controller.Move(velocity * Time.deltaTime * 20f);
        }
        */
    }
}